using CarSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Services.Interface
{
    public interface IBorrowingService
    {
        void AddBorrowing(Borrowing borrowing);
        void UpdateBorrowing(Borrowing borrowing);
        IEnumerable<Borrowing> GetAllBorrowing();
        IEnumerable<Borrowing> GetBorrowingsByBorrowerId(string borrowerId);
        Borrowing GetBorrowingsById(int borrowingId);
        void DeleteWithId(int borrowingId);
        IEnumerable<Borrowing> GetBorrowingsForCarOwner(string carOwnerId);
        void UpdateToAccepted(Borrowing borrowing);
        void UpdateToRejected(Borrowing borrowing);
    }
}
