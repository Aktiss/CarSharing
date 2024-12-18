using Microsoft.EntityFrameworkCore;
using Web_API_CarSharing.Data;
using Web_API_CarSharing.Entities;

namespace Web_API_CarSharing.Repositories
{
	public class BorrowingRepository : IBorrowingRepository
	{
		private readonly CarSharingAPIDBContext _context;
		public BorrowingRepository(CarSharingAPIDBContext carSharingAPIDBContext)
		{
			_context = carSharingAPIDBContext;
		}
		public IEnumerable<Borrowing> GetAll()
		{
			return _context.Borrowings.ToList();
		}

		public Borrowing GetById(int id)
		{
			return _context.Borrowings.SingleOrDefault();
		}
	}
}
