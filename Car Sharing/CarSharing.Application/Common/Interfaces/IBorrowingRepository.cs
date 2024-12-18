 using CarSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Common.Interfaces
{
    public interface IBorrowingRepository
    {
        void Add(Borrowing borrowing);
        void Update(Borrowing borrowing);
        void Delete(Borrowing borrowing);
        Borrowing GetById(int id);
        IEnumerable<Borrowing> GetByCarId(int carId);
        IEnumerable<Borrowing> GetByBorrowerId(string borrowerId);
        IEnumerable<Borrowing> GetByCarOwnerId(string carOwnerId);
        IEnumerable<Borrowing> GetAll();
        
    }
}
