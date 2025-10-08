using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllSales();
        Task<int> CreateSale(Sale sale);
        Task<int> UpdateSale(int id, int carId, DateOnly saleDate, int employeeId, int state);
        Task<int> DeleteSale(int id);
    }
}
