using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using CarSharing.Infrastructure.identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Infrastructure.Data
{
    public class CarSharingDBContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Car>().HasData(
                new Car() { Id = 1, Brand = "Audi", Model = "A3", Description = "Goeie staat", Year = 2020, Seats = 5, Fueltype = FueltypeEnum.Petrol, Transmission = TransmissionEnum.Automatic, ImageURL = "https://mediaservice.audi.com/media/fast/H4sIAAAAAAAAAFvzloG1tIiBOTrayfuvpGh6-m1zJgaGigIGBgZGoDhTtNOaz-I_2DhCHsCEtzEwF-SlMwJZKUycmbmJ6an6QD4_I3taTmV-aUkxO0grT9Pa4LcrgmzOW3se3ft8EstCCWHRLQysQF2Ml4AEiwiQ4IsCEhzhDGASZN5CEHESxGcyZ2ZgYK0AMiIZQICPr7QopyCxKDFXrzwzpSRDUMOASCDM7uIa4ujpEwwAdTReUOkAAAA?wid=550", OwnerId = "268fd75b-5b27-455f-9f3d-a6c49db19db9" },
                new Car() { Id = 2, Brand = "Citroën", Model = "Berlingo", Description = "Goede staat", Year = 2014, Seats = 5, Fueltype = FueltypeEnum.Diesel, Transmission = TransmissionEnum.Manual, ImageURL = "https://www.citroen.be/content/dam/citroen/master/no-config/noconfig-eberlingo/ice/m/xtr/kiamablue_Berlingo_M.png?imwidth=768", OwnerId = "268fd75b-5b27-455f-9f3d-a6c49db19db9" },
                new Car() { Id = 3, Brand = "Ferrari", Model = "Enzo", Description = "Mooi", Year = 2010, Seats = 4, Fueltype = FueltypeEnum.CNG, Transmission = TransmissionEnum.Automatic, ImageURL = "https://www.bloemendaalcs.nl/wp-content/uploads/2015/07/2015-Ferrari-Enzo-Luxury-Automotive.jpg", OwnerId = "2" }
                );

            builder.Entity<Borrowing>().HasData(
            new Borrowing()
            {
                Id = 1,
                StartDateTime = new DateTime(2024, 8, 21, 9, 0, 0),
                EndDateTime = new DateTime(2024, 8, 30, 17, 0, 0),
                Status = StatusEnum.Accepted,
                CarId = 1,
                Message = "Borrowing the Audi for a day trip.",
                BorrowerId = "268fd75b-5b27-455f-9f3d-a6c49db19db9"
            },
            new Borrowing()
            {
                Id = 2,
                StartDateTime = new DateTime(2024, 8, 2, 10, 0, 0),
                EndDateTime = new DateTime(2024, 8, 2, 18, 0, 0),
                Status = StatusEnum.Pending,
                CarId = 2,
                Message = "Need the Citroën for moving some items.",
                BorrowerId = "268fd75b-5b27-455f-9f3d-a6c49db19db9"
            }
            );
        }

        public CarSharingDBContext(DbContextOptions<CarSharingDBContext> options) : base(options) 
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
    }
}
