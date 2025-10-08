using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrands();
    }
}
