using Microsoft.EntityFrameworkCore;
using CarDealer.Core.Abstractions;
using CarDealer.Core.Models;
using CarDealer.DataAccess.Entities;
using CarDealer.DataAccess.DatabaseContext;

namespace CarDealer.DataAccess.Repos
{
    public class CarRepo : ICarRepo
    {
        private readonly CarDealerDbContext context;

        public CarRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Car>> Get()
        {
            return await context.Cars
                .Include(c => c.Complect)
                    .ThenInclude(co => co.Model)
                        .ThenInclude(m => m.Brand)
                            .ThenInclude(b => b.Country)
                .Include(c => c.Color)
                .AsNoTracking()
                .Select(x => Car.Create(
                    x.Id,
                    x.ComplectId,
                    x.ColorId,
                    x.Year,
                    x.Price,
                    x.State,
                    MapComplect(x.Complect),
                    MapColor(x.Color)
                ))
                .ToListAsync();
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

        public async Task<int> Create(Car car)
        {
            var carEntity = new CarEntity
            {
                Id = car.Id,
                ComplectId = car.ComplectId,
                ColorId = car.ColorId,
                Year = car.Year,
                Price = car.Price,
                State = car.State
            };

            await context.Cars.AddAsync(carEntity);
            await context.SaveChangesAsync();

            return carEntity.Id;
        }

        public async Task<int> Update(int id, int complectId, int colorId, int year, decimal price, int state)
        {
            await context.Cars
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.Id, p => id)
                    .SetProperty(p => p.ComplectId, p => complectId)
                    .SetProperty(p => p.ColorId, p => colorId)
                    .SetProperty(p => p.Year, p => year)
                    .SetProperty(p => p.Price, p => price)
                    .SetProperty(p => p.State, p => state));

            return id;
        }

        public async Task<int> Delete(int id)
        {
            await context.Cars
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
