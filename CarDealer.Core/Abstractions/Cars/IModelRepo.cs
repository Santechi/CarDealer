using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IModelRepo
    {
        Task<List<Model>> Get();
    }
}
