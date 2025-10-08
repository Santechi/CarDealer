using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Sales
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> Get();
    }
}
