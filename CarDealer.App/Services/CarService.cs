using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.App.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepo carRepo;

        public CarService(ICarRepo carRepo)
        {
            this.carRepo = carRepo;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await carRepo.Get();
        }

        public async Task<int> CreateCar(Car car)
        {
            return await carRepo.Create(car);
        }

        public async Task<int> DeleteCar(int id)
        {
            return await carRepo.Delete(id);
        }

        public async Task<int> DeleteCarPermanently(int id)
        {
            return await carRepo.DeletePermanently(id);
        }

        public async Task<int> UpdateCar(int id, int complectId, int colorId, int year, decimal price, int state)
        {
            return await carRepo.Update(id, complectId, colorId, year, price, state);
        }
    }
}
