using CarSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Common.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int id);
        IEnumerable<Car> GetByOwnerId(string ownerid);
        IEnumerable<Car> GetAll();
    }
}
