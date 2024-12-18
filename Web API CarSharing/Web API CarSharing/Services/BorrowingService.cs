using Web_API_CarSharing.Dto_s;
using Web_API_CarSharing.Entities;
using Web_API_CarSharing.Repositories;

namespace Web_API_CarSharing.Services
{
	public class BorrowingService : IBorrowingService
	{

		private readonly IUnitOfWork _unitOfWork;
		public BorrowingService(IUnitOfWork unitofwork)
		{
			_unitOfWork = unitofwork;
		}

		public Borrowing GetBorrowingById(int Id)
		{
			return _unitOfWork.Borrowing.GetById(Id);
		}

		public IEnumerable<Borrowing> GetIncoming(string userId)
		{
			return _unitOfWork.Borrowing.GetAll()
				.Where(x => x.Car.OwnerId == userId)
				.OrderBy(x => x.StartDateTime);
				
		}

		public IEnumerable<Borrowing> GetOutgoing(string userId)
		{
			return _unitOfWork.Borrowing.GetAll()
				.Where(x => x.BorrowerId == userId)
				.OrderBy(x => x.StartDateTime);
		}

		public void UpdateToAccepted(Borrowing borrowing)
		{
			borrowing.Status = Enumerations.StatusEnum.Accepted;
			_unitOfWork.SaveChanges();
		}

		public void UpdateToRejected(Borrowing borrowing)
		{
			borrowing.Status = Enumerations.StatusEnum.Rejected;
			_unitOfWork.SaveChanges();
		}
	}
}
