using CarDealer.Core.Models.Sales;

namespace CarDealer.Core.Abstractions.Sales
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
    }
}
