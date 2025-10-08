using CarDealer.Core.Abstractions.Sales;
using CarDealer.Core.Models.Sales;

namespace CarDealer.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await employeeRepo.Get();
        }
    }
}
