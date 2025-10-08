using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.DataAccess.Repos
{
    public class BrandRepo : IBrandRepo
    {
        private readonly CarDealerDbContext context;

        public BrandRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Brand>> Get()
        {
            return await context.Brands
                .Where(x => x.State == 0)
                .Include(b => b.Country)
                .AsNoTracking()
                .Select(x => Brand.Create(
                    x.Id,
                    x.Name,
                    x.CountryId,
                    x.State,
                    MapHelper.MapCountry(x.Country)
                ))
                .ToListAsync();
        }
    }
}
