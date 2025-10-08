using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IColorService
    {
        Task<List<Color>> GetAllColors();
    }
}
