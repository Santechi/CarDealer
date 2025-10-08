using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.App.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo brandRepo;

        public BrandService(IBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            return await brandRepo.Get();
        }
    }
}
