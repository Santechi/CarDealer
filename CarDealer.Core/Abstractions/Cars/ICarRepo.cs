using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface ICarRepo
    {
        Task<int> Create(Car car);
        Task<int> Delete(int id);
        Task<List<Car>> Get();
        Task<int> Update(int id, int complectId, int colorId, int year, decimal price, int state);
    }
}
