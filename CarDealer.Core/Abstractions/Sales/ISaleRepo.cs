using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Cars
{
    public interface ISaleRepo
    {
        Task<int> Create(Sale sale);
        Task<int> Delete(int id);
        Task<List<Sale>> Get();
        Task<int> Update(int id, int carId, DateTime saleDate, int employeeId, int state);
    }
}
