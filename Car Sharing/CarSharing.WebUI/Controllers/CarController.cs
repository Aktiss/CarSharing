using CarSharing.Application.Services.Interface;
using CarSharing.Domain.Entities;
using CarSharing.Infrastructure.identity;
using CarSharing.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

namespace CarSharing.WebUI.Controllers
{
    public class CarController : Controller
    {

        private ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CarController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _carService = carService;
        }
        public IActionResult Index()
        {
            return View(_carService.GetAllCars());
        }
        public IActionResult Details(int id)
        {
            Car car = _carService.GetCarById(id);
            DetailsViewModel model = new DetailsViewModel(car);
            return View(model);
        }

		[Authorize]
        public async Task<IActionResult> Manage()
        {
            string userId =  _userManager.GetUserId(User);
            IEnumerable<Car> cars = _carService.GetAllCarsByOwner(userId);
            return View(cars);
        }

        [Authorize]
        public IActionResult AddCar() 
        {
            CarForm form = new CarForm();
            return View(form);
        }

        [Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddCar(CarForm form)
        {

            if (ModelState.IsValid)
            {
                Car car = new Car(form.Brand, form.Model, form.Description, form.Year, form.Seats, form.Fueltype, form.Transmission, form.ImageURL, _userManager.GetUserId(User));

                _carService.AddCar(car);

                return RedirectToAction("Success", "Home");
            }

            return View(form);

        }
    }
}
