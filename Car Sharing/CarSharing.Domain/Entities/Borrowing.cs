using CarSharing.Domain.Enumerations;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Entities
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

        public Borrowing() { }

        public Borrowing(DateTime startDateTime, DateTime endDateTime, int carId, string message, string borrowerId)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = StatusEnum.Pending;
            CarId = carId;
            Message = message;
            BorrowerId = borrowerId;
        }
    }
}
