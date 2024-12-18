using CarSharing.Domain.Entities;

namespace CarSharing.WebUI.Models
{
    public class DetailsViewModel
    {
        public Car Car {  get; set; }
        public DetailsViewModel(Car c)
        {
            Car = c;
        }
    }
}
