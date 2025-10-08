using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<int> CreateCar(Car car);
        Task<int> UpdateCar(int id, int complectId, int colorId, int year, decimal price, int state);
        Task<int> DeleteCar(int id);
        Task<int> DeleteCarPermanently(int id);
    }
}
