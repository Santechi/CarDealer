using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IColorRepo
    {
        Task<List<Color>> Get();
    }
}
