using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.DataAccess.Entities.Cars;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;
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
                    MapCar(x.Car),
                    MapEmployee(x.Employee)
                ))
                .ToListAsync();
        }

        private static Car? MapCar(CarEntity? entity)
        {
            if (entity == null)
                return null;

            return Car.Create(
                entity.Id,
                entity.ComplectId,
                entity.ColorId,
                entity.Year,
                entity.Price,
                entity.State,
                MapComplect(entity.Complect),
                MapColor(entity.Color)
            );
        }

        private static Country? MapCountry(CountryEntity? entity)
        {
            if (entity == null)
                return null;

            return Country.Create(
                entity.Id,
                entity.Name,
                entity.State
            );
        }

        private static Brand? MapBrand(BrandEntity? entity)
        {
            if (entity == null)
                return null;

            return Brand.Create(
                entity.Id,
                entity.Name,
                entity.CountryId,
                entity.State,
                MapCountry(entity.Country)
            );
        }

        private static Model? MapModel(ModelEntity? entity)
        {
            if (entity == null)
                return null;

            return Model.Create(
                entity.Id,
                entity.BrandId,
                entity.Name,
                entity.State,
                MapBrand(entity.Brand)
            );
        }

        private static Complect? MapComplect(ComplectEntity? entity)
        {
            if (entity == null)
                return null;

            return Complect.Create(
                entity.Id,
                entity.ModelId,
                entity.Name,
                entity.Engine,
                entity.Transmission,
                entity.State,
                MapModel(entity.Model)
            );
        }

        private static Color? MapColor(ColorEntity? entity)
        {
            if (entity == null)
                return null;

            return Color.Create(
                entity.Id,
                entity.Name,
                entity.State
            );
        }

        private static Employee? MapEmployee(EmployeeEntity? entity)
        {
            if (entity == null)
                return null;

            return Employee.Create(
                entity.Id,
                entity.Fio,
                entity.Email,
                entity.Phone,
                entity.State
            );
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

        public async Task<int> Update(int id, int carId, DateTime saleDate, int employeeId, int state)
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
