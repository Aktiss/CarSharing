using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CarSharing.WebUI.Models
{
    public class CarForm
	{
        [Required(ErrorMessage = "Brand is required.")]
        [Display(Name ="Brand of the car")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [Display(Name ="Model of the car")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name ="Describe the car")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Please enter a valid year.")]
        [Display(Name ="Year you bought the car")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Number of seats is required.")]
        [Range(2, 20, ErrorMessage = "Please enter a valid number of seats.")]
        [Display(Name ="How many seats")]
        public int Seats { get; set; }

        [Display(Name ="Type of fuel")]
        [Required(ErrorMessage = "Fuel type is required.")]
        public FueltypeEnum Fueltype { get; set; }

        [Required(ErrorMessage = "Transmission type is required.")]
        public TransmissionEnum Transmission { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [Display(Name ="URL of a picture of the car")]
        public string ImageURL { get; set; }
    }
}
