using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IComplectService
    {
        Task<List<Complect>> GetAllComplects();
    }
}
