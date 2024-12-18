using Web_API_CarSharing.Enumerations;

namespace Web_API_CarSharing.Dto_s
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Seats { get; set; }
        public FueltypeEnum Fueltype { get; set; }
        public TransmissionEnum Transmission { get; set; }
        public string OwnerId { get; set; }
    }
}
