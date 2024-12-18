using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using CarSharing.WebUI.ValidationAtributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarSharing.WebUI.Models
{
    public class BorrowingForm
    {
        public BorrowingForm()
        {
            StartDateTime = DateTime.Today;
            EndDateTime = DateTime.Today;
        }

        [Required]
        [Display(Name ="Start Date")]
        [FutureDate(ErrorMessage ="Start date must be in the future")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name ="End Date")]
        [FutureDate(ErrorMessage ="End date must be in the future")]
        public DateTime EndDateTime { get; set; }
        [Required]
        public int CarId { get; set; }
        [ValidateNever]
        public string Message { get; set; }
    }
}
