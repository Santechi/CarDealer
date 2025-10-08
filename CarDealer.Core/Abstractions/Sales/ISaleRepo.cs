using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Sales
{
    public interface ISaleRepo
    {
        Task<int> Create(Sale sale);
        Task<int> Delete(int id);
        Task<int> DeletePermanently(int id);
        Task<List<Sale>> Get();
        Task<int> Update(int id, int carId, DateOnly saleDate, int employeeId, int state);
    }
}
