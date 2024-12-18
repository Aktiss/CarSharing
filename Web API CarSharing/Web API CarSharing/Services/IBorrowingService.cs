using Web_API_CarSharing.Dto_s;
using Web_API_CarSharing.Entities;

namespace Web_API_CarSharing.Services
{
	public interface IBorrowingService
	{
		IEnumerable<Borrowing> GetIncoming(string userId);
		IEnumerable<Borrowing> GetOutgoing(string userId);
		Borrowing GetBorrowingById(int Id);
		void UpdateToAccepted(Borrowing borrowing);
		void UpdateToRejected(Borrowing borrowing);

	}
}
