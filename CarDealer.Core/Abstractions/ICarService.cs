using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealer.Core.Models;

namespace CarDealer.Core.Abstractions
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<int> CreateCar(Car car);
        Task<int> UpdateCar(int id, int complectId, int colorId, int year, decimal price, int state);
        Task<int> DeleteCar(int id);
    }
}
