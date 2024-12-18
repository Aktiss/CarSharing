using CarSharing.Application.Common.Interfaces;
using CarSharing.Domain.Entities;
using CarSharing.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarSharingDBContext _context;

        public CarRepository(CarSharingDBContext context)
        {
            _context = context;
        }
        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();

        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Cars.Find(id);
        }

        public IEnumerable<Car> GetByOwnerId(string ownerid)
        {
            return _context.Cars.Where(x => x.OwnerId == ownerid).ToList();
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
        }
    }
}
