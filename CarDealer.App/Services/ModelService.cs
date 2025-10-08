using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.App.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepo modelRepo;

        public ModelService(IModelRepo modelRepo)
        {
            this.modelRepo = modelRepo;
        }

        public async Task<List<Model>> GetAllModels()
        {
            return await modelRepo.Get();
        }
    }
}
