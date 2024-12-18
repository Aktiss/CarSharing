using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_API_CarSharing.Authentication;
using Web_API_CarSharing.Entities;
using Web_API_CarSharing.Enumerations;

namespace Web_API_CarSharing.Data
{
    public class CarSharingAPIDBContext : IdentityDbContext<ApplicationUser>
    {
        public CarSharingAPIDBContext(DbContextOptions<CarSharingAPIDBContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Cars
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Brand = "Tesla",
                    Model = "Model S",
                    Description = "A luxury electric sedan.",
                    Year = 2020,
                    Seats = 5,
                    Fueltype = FueltypeEnum.CNG,
                    Transmission = TransmissionEnum.Automatic,
                    ImageURL = "https://example.com/tesla-model-s.jpg",
                    OwnerId = "owner1"
                },
                new Car
                {
                    Id = 2,
                    Brand = "Toyota",
                    Model = "Corolla",
                    Description = "A reliable compact car.",
                    Year = 2019,
                    Seats = 5,
                    Fueltype = FueltypeEnum.Petrol,
                    Transmission = TransmissionEnum.Manual,
                    ImageURL = "https://example.com/toyota-corolla.jpg",
                    OwnerId = "owner2"
                },
                new Car
                {
                    Id = 3,
                    Brand = "Ford",
                    Model = "Mustang",
                    Description = "A classic American muscle car.",
                    Year = 2018,
                    Seats = 4,
                    Fueltype = FueltypeEnum.Petrol,
                    Transmission = TransmissionEnum.Automatic,
                    ImageURL = "https://example.com/ford-mustang.jpg",
                    OwnerId = "owner3"
                }
            );

            // Seeding Borrowings
            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing
                {
                    Id = 1,
                    StartDateTime = new DateTime(2024, 8, 23, 10, 0, 0),
                    EndDateTime = new DateTime(2024, 8, 23, 18, 0, 0),
                    Status = StatusEnum.Pending,
                    CarId = 1,
                    Message = "Great experience!",
                    BorrowerId = "borrower1"
                },
                new Borrowing
                {
                    Id = 2,
                    StartDateTime = new DateTime(2024, 8, 24, 9, 0, 0),
                    EndDateTime = new DateTime(2024, 8, 24, 17, 0, 0),
                    Status = StatusEnum.Accepted,
                    CarId = 2,
                    Message = null,
                    BorrowerId = "borrower2"
                },
                new Borrowing
                {
                    Id = 3,
                    StartDateTime = new DateTime(2024, 8, 25, 14, 0, 0),
                    EndDateTime = new DateTime(2024, 8, 25, 20, 0, 0),
                    Status = StatusEnum.Rejected,
                    CarId = 3,
                    Message = "Change of plans, need to cancel.",
                    BorrowerId = "borrower3"
                }
            );
        }
    }
}
