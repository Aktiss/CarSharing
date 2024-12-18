using Web_API_CarSharing.Entities;

namespace Web_API_CarSharing.Repositories
{
	public interface IBorrowingRepository
	{
		IEnumerable<Borrowing> GetAll();
		Borrowing GetById(int id);
	}
}
