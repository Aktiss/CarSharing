using System;
using Web_API_CarSharing.Data;

namespace Web_API_CarSharing.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICarRepository Cars { get; set; }

		public IBorrowingRepository Borrowing { get; set; }

		private readonly CarSharingAPIDBContext _context;

        public UnitOfWork(CarSharingAPIDBContext context)
        {
            _context = context;
            Cars = new CarRepository(context);
            Borrowing = new BorrowingRepository(context);
		}

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
