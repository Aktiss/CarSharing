using CarSharing.Application.Common.Interfaces;
using CarSharing.Application.Services.Interface;
using CarSharing.Domain.Entities;
using CarSharing.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Services.Implementation
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public  BorrowingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            _unitOfWork.Borrowings.Add(borrowing);
            _unitOfWork.Save();
        }

        public void DeleteWithId(int borrowingId)
        {
            Borrowing borrowing = _unitOfWork.Borrowings.GetById(borrowingId);
            _unitOfWork.Borrowings.Delete(borrowing);
            _unitOfWork.Save();
        }

        public IEnumerable<Borrowing> GetAllBorrowing()
        {
            return _unitOfWork.Borrowings.GetAll();
        }

        public IEnumerable<Borrowing> GetBorrowingsByBorrowerId(string borrowerId)
        {
            return _unitOfWork.Borrowings.GetByBorrowerId(borrowerId);
        }

        public Borrowing GetBorrowingsById(int borrowingId)
        {
            return _unitOfWork.Borrowings.GetById(borrowingId);
        }

        public IEnumerable<Borrowing> GetBorrowingsForCarOwner(string carOwnerId)
        {
            return _unitOfWork.Borrowings.GetByCarOwnerId(carOwnerId);
        }

        public void UpdateBorrowing(Borrowing borrowing)
        {
            _unitOfWork.Borrowings.Update(borrowing);
        }

        public void UpdateToAccepted(Borrowing borrowing)
        {
            borrowing.Status = StatusEnum.Accepted;
            _unitOfWork.Save();
        }

        public void UpdateToRejected(Borrowing borrowing)
        {
            borrowing.Status = StatusEnum.Rejected;
            _unitOfWork.Save();
        }
    }
}
