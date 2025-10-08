using CarDealer.Core.Models.Cars;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface IModelService
    {
        Task<List<Model>> GetAllModels();
    }
}
