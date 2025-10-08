using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IComplectRepo
    {
        Task<List<Complect>> Get();
    }
}
