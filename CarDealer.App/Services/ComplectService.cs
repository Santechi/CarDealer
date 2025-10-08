using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.App.Services
{
    public class ComplectService : IComplectService
    {
        private readonly IComplectRepo complectRepo;

        public ComplectService(IComplectRepo modelRepo)
        {
            this.complectRepo = modelRepo;
        }

        public async Task<List<Complect>> GetAllComplects()
        {
            return await complectRepo.Get();
        }
    }
}
