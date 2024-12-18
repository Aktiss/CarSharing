using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_API_CarSharing.Enumerations;

namespace Web_API_CarSharing.Entities
{
    public class Borrowing
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public DateTime StartDateTime { get; set; }
		[Required]
		public DateTime EndDateTime { get; set; }
		[Required]
		public StatusEnum Status { get; set; }
		[Required]
		[ForeignKey("CarId")]
		public Car Car { get; set; }
		public int CarId { get; set; }
		public string? Message { get; set; }
		[Required]
		public string BorrowerId { get; set; }
	}
}
