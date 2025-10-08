using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.DataAccess.Repos
{
    public class ModelRepo : IModelRepo
    {
        private readonly CarDealerDbContext context;

        public ModelRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Model>> Get()
        {
            return await context.Models
                .Where(x => x.State == 0)
                .Include(m => m.Brand)
                    .ThenInclude(b => b.Country)
                .AsNoTracking()
                .Select(x => Model.Create(
                    x.Id,
                    x.BrandId,
                    x.Name,
                    x.State,
                    MapHelper.MapBrand(x.Brand))
                ).ToListAsync();
        }
    }
}
