using Web_API_CarSharing.Dto_s;
using Web_API_CarSharing.Entities;
using Web_API_CarSharing.Repositories;

namespace Web_API_CarSharing.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitofwork) 
        {
            _unitOfWork = unitofwork;
        }
        public IEnumerable<CarDto> GetAll()
        {
            return _unitOfWork.Cars.GetAll().Select(ConvertToCarDto);
        }

        private static CarDto ConvertToCarDto(Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                Year = car.Year,
                Seats = car.Seats,
                Fueltype = car.Fueltype,
                Transmission = car.Transmission,
                OwnerId = car.OwnerId
            };
        }
    }
}
