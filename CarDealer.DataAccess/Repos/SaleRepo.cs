using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Sales;
using CarDealer.DataAccess.Entities.Sales;

namespace CarDealer.DataAccess.Repos
{
    public class SaleRepo : ISaleRepo
    {
        private readonly CarDealerDbContext context;

        public SaleRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Sale>> Get()
        {
            return await context.Sales
                .Where(x => x.State == 0)
                .Include(c => c.Car)
                    .ThenInclude(c => c.Complect)
                        .ThenInclude(c => c.Model)
                            .ThenInclude(m => m.Brand)
                                .ThenInclude(b => b.Country)
                .Include(c => c.Employee)
                .AsNoTracking()
                .Select(x => Sale.Create(
                    x.Id,
                    x.CarId,
                    x.SaleDate,
                    x.EmployeeId,
                    x.State,
                    MapHelper.MapCar(x.Car),
                    MapHelper.MapEmployee(x.Employee)
                ))
                .ToListAsync();
        }

        public async Task<int> Create(Sale sale)
        {
            var saleEntity = new SaleEntity
            {
                Id = sale.Id,
                CarId = sale.CarId,
                SaleDate = sale.SaleDate,
                EmployeeId = sale.EmployeeId,
                State = sale.State
            };

            await context.Sales.AddAsync(saleEntity);
            await context.SaveChangesAsync();

            return saleEntity.Id;
        }

        public async Task<int> Update(int id, int carId, DateOnly saleDate, int employeeId, int state)
        {
            await context.Sales
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.Id, p => id)
                    .SetProperty(p => p.CarId, p => carId)
                    .SetProperty(p => p.SaleDate, p => saleDate)
                    .SetProperty(p => p.EmployeeId, p => employeeId)
                    .SetProperty(p => p.State, p => state));

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await context.Sales
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
