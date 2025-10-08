using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.DataAccess.Entities.Cars;
using Microsoft.EntityFrameworkCore;

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
                .Where(x => x.State == 0)
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
                    MapHelper.MapComplect(x.Complect),
                    MapHelper.MapColor(x.Color)
                ))
                .ToListAsync();
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
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.State, p => 1));

            return id;
        }

        public async Task<int> DeletePermanently(int id)
        {
            await context.Cars
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
