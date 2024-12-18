using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API_CarSharing.Authentication;
using Web_API_CarSharing.Dto_s;
using Web_API_CarSharing.Entities;
using Web_API_CarSharing.Model;
using Web_API_CarSharing.Services;

namespace Web_API_CarSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSharingController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IBorrowingService _borrowingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public CarSharingController(ICarService carService, IBorrowingService borrowingService, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _carService = carService;
            _borrowingService = borrowingService;
			this.userManager = userManager;
            _configuration = configuration;
            this.roleManager = roleManager;
        }

        [Route("/cars")]
        [HttpGet]
        public ActionResult<IEnumerable<CarDto>> GetAllCars()
        {
            return Ok(_carService.GetAll());
        }

        [Route("/me/borrowings/{type}")]
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Borrowing>> GetBorrowings(string type)
        {
            if (type == "incoming") 
            {
				IEnumerable<Borrowing> borrowings = _borrowingService.GetIncoming(userManager.GetUserId(User));
                return Ok(borrowings);
            } else if (type == "outgoing")
            {
				IEnumerable<Borrowing> borrowings = _borrowingService.GetOutgoing(userManager.GetUserId(User));
                return Ok(borrowings);
			}
			else
            {
				return BadRequest("Invalid type parameter. Expected 'incoming' or 'outgoing'.");
			}
        }

        [Route("/borrowings/{id}/accept")]
        [HttpPut]
		[Authorize]
		public ActionResult Update(int id)
        {
            Borrowing borrowing = _borrowingService.GetBorrowingById(id);
            if (userManager.GetUserId(User) != borrowing.Car.OwnerId)
            {
                return BadRequest("You can't accept a borrowing request to someone else's car");
            }
            if (borrowing == null)
            {
                return NotFound("Invalid id parameter. This id does not exist");
            }
            
            _borrowingService.UpdateToAccepted(borrowing);
            return Ok(borrowing);
        }

		[Route("/borrowings/{id}/reject")]
		[HttpDelete]
		[Authorize]
		public ActionResult Delete(int id)
		{
			Borrowing borrowing = _borrowingService.GetBorrowingById(id);
			if (userManager.GetUserId(User) != borrowing.Car.OwnerId)
			{
				return BadRequest("You can't accept a borrowing request to someone else's car");
			}
			if (borrowing == null)
			{
				return BadRequest("Invalid id parameter. This id does not exist");
			}
			_borrowingService.UpdateToRejected(borrowing);
			return Ok(borrowing);
		}

		[HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
