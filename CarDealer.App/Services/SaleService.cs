using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Sales;

namespace CarDealer.App.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepo saleRepo;

        public SaleService(ISaleRepo saleRepo)
        {
            this.saleRepo = saleRepo;
        }

        public async Task<List<Sale>> GetAllSales()
        {
            return await saleRepo.Get();
        }

        public async Task<int> CreateSale(Sale sale)
        {
            return await saleRepo.Create(sale);
        }

        public async Task<int> DeleteSale(int id)
        {
            return await saleRepo.Delete(id);
        }

        public async Task<int> UpdateSale(int id, int carId, DateOnly saleDate, int employeeId, int state)
        {
            return await saleRepo.Update(id, carId, saleDate, employeeId, state);
        }
    }
}
