using CarSharing.Application.Services.Implementation;
using CarSharing.Application.Services.Interface;
using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using CarSharing.Infrastructure.identity;
using CarSharing.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.WebUI.Controllers
{
    public class BorrowingController : Controller
    {
        private IBorrowingService _borrowingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BorrowingController(IBorrowingService borrowingService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _borrowingService= borrowingService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Borrowing> borrowings = _borrowingService.GetBorrowingsByBorrowerId(_userManager.GetUserId(User));
            return View(borrowings);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int borrowingId)
        {
            _borrowingService.DeleteWithId(borrowingId);
            return RedirectToAction("Index");
        }

        

        [Authorize]
        public IActionResult AddBorrowing(int carId)
        {
            ViewData["carId"] = carId;
            BorrowingForm form = new BorrowingForm();
            return View(form);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBorrowing(BorrowingForm form)
        {

            if (ModelState.IsValid)
            {
                Borrowing borrowing = new Borrowing(form.StartDateTime,form.EndDateTime,form.CarId,form.Message, _userManager.GetUserId(User));

                _borrowingService.AddBorrowing(borrowing);

                return RedirectToAction("Success", "Home");
            }

            return View(form);

        }

        [Authorize]
        public IActionResult IncommingBorrowings()
        {
            IEnumerable<Borrowing> borrowings = _borrowingService.GetBorrowingsForCarOwner(_userManager.GetUserId(User));
            return View(borrowings);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Accept(int borrowingId)
        {
            Borrowing borrowing = _borrowingService.GetBorrowingsById(borrowingId);
            _borrowingService.UpdateToAccepted(borrowing);
            return RedirectToAction("IncommingBorrowings");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Reject(int borrowingId)
        {
            Borrowing borrowing = _borrowingService.GetBorrowingsById(borrowingId);
            _borrowingService.UpdateToRejected(borrowing);
            return RedirectToAction("IncommingBorrowings");
        }

        [Authorize (Policy ="AdminOnly")]
        public IActionResult GetAll()
        {
            IEnumerable<Borrowing> borrowings = _borrowingService.GetAllBorrowing();
            return View(borrowings);
        }
    }
}
