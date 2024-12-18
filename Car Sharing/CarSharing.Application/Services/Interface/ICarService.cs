using CarSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Services.Interface
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int carId);
        IEnumerable<Car> GetAllCarsByOwner(string ownerId);
        void AddCar(Car car);

    }
}
