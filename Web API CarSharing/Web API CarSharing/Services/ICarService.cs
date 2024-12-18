using Web_API_CarSharing.Dto_s;

namespace Web_API_CarSharing.Services
{
    public interface ICarService
    {
        IEnumerable<CarDto> GetAll();
    }
}
