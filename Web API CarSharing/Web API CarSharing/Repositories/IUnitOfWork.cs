namespace Web_API_CarSharing.Repositories
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        IBorrowingRepository Borrowing { get; }
        void SaveChanges();
    }
}
