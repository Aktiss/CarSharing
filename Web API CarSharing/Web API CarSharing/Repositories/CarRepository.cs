using Microsoft.EntityFrameworkCore;
using System;
using Web_API_CarSharing.Data;
using Web_API_CarSharing.Entities;

namespace Web_API_CarSharing.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarSharingAPIDBContext _context;
        public CarRepository(CarSharingAPIDBContext carSharingAPIDBContext) 
        {
            _context = carSharingAPIDBContext;
        }
        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }
    }
}
