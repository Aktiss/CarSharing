using System.ComponentModel.DataAnnotations;
using Web_API_CarSharing.Enumerations;

namespace Web_API_CarSharing.Entities
{
    public class Car
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Brand { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public int Year { get; set; }
		[Required]
		public int Seats { get; set; }
		[Required]
		public FueltypeEnum Fueltype { get; set; }
		[Required]
		public TransmissionEnum Transmission { get; set; }
		[Required]
		public string ImageURL { get; set; }
		[Required]
		public string OwnerId { get; set; }
		public ICollection<Borrowing> Borrowings { get; set; }
	}
}
