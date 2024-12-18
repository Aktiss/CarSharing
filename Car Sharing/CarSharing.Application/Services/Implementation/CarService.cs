using CarSharing.Application.Common.Interfaces;
using CarSharing.Application.Services.Interface;
using CarSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Services.Implementation
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _unitOfWork.Cars.GetAll();
        }

        public Car GetCarById(int carId)
        {
            return _unitOfWork.Cars.GetById(carId);
        }

        public IEnumerable<Car> GetAllCarsByOwner (string ownerId)
        {
            return _unitOfWork.Cars.GetByOwnerId(ownerId);
        }

		public void AddCar(Car car)
		{
			_unitOfWork.Cars.Add(car);
            _unitOfWork.Save();
		}
	}
}
