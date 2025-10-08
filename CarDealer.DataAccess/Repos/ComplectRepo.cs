using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.DataAccess.Repos
{
    public class ComplectRepo : IComplectRepo
    {
        private readonly CarDealerDbContext context;

        public ComplectRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Complect>> Get()
        {
            return await context.Complects
                .Where(x => x.State == 0)
                .Include(m => m.Model)
                    .ThenInclude(b => b.Brand)
                        .ThenInclude(b => b.Country)
                .AsNoTracking()
                .Select(x => Complect.Create(
                    x.Id,
                    x.ModelId,
                    x.Name,
                    x.Engine,
                    x.Transmission,
                    x.State,
                    MapHelper.MapModel(x.Model))
                ).ToListAsync();
        }
    }
}
