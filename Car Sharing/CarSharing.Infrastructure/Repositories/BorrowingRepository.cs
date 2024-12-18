using CarSharing.Application.Common.Interfaces;
using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using CarSharing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Infrastructure.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly CarSharingDBContext _context;

        public BorrowingRepository(CarSharingDBContext context)
        {
            _context = context;
        }
        public void Add(Borrowing borrowing)
        {
            _context.Add(borrowing);
        }

        public void Delete(Borrowing borrowing)
        {
            _context.Remove(borrowing);
        }

        public IEnumerable<Borrowing> GetAll()
        {
            return _context.Borrowings
                .OrderBy(x => x.StartDateTime)
                .Include(x => x.Car)
                .ToList();
        }

        public IEnumerable<Borrowing> GetByBorrowerId(string borrowerId)
        {
            return _context.Borrowings
                .Where(x => x.BorrowerId == borrowerId)
                .OrderBy(x => x.StartDateTime)
                .Include(x => x.Car)
                .ToList();
        }

        public IEnumerable<Borrowing> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrowing> GetByCarOwnerId(string carOwnerId)
        {
            return _context.Borrowings
                .Include(x => x.Car)
                .Where(x => x.Car.OwnerId == carOwnerId)
                .OrderBy(x => x.StartDateTime)
                .ToList();
        }

        public Borrowing GetById(int id)
        {
            return _context.Borrowings.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(Borrowing borrowing)
        {
            _context.Borrowings.Update(borrowing);
        }
    }
}
