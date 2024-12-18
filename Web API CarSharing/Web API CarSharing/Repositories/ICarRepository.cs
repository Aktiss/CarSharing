using Web_API_CarSharing.Entities;

namespace Web_API_CarSharing.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
    }
}
