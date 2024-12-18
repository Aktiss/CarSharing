using CarSharing.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Entities
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

        public Car() { }

        public Car (string brand, string model, string description, int year, int seats, FueltypeEnum fueltype, TransmissionEnum transmission, string imageURL, string ownerId)
        {
            Brand = brand;
            Model = model;
            Description = description;
            Year = year;
            Seats = seats;
            Fueltype = fueltype;
            Transmission = transmission;
            ImageURL = imageURL;
            OwnerId = ownerId;
        }
    }
}
