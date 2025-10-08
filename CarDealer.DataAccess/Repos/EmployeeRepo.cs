using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Models.Sales;
using CarDealer.DataAccess.Entities.Sales;
using CarDealer.Core.Abstractions.Sales;

namespace CarDealer.DataAccess.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly CarDealerDbContext context;

        public EmployeeRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> Get()
        {
            return await context.Employees
                .Where(x => x.State == 0)
                .AsNoTracking()
                .Select(x => Employee.Create(
                    x.Id,
                    x.Fio,
                    x.Email,
                    x.Phone,
                    x.State
                ))
                .ToListAsync();
        }
    }
}
