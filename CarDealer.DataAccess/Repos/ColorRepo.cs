using Microsoft.EntityFrameworkCore;
using CarDealer.DataAccess.DatabaseContext;
using CarDealer.Core.Abstractions.Cars;
using CarDealer.Core.Models.Cars;

namespace CarDealer.DataAccess.Repos
{
    public class ColorRepo : IColorRepo
    {
        private readonly CarDealerDbContext context;

        public ColorRepo(CarDealerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Color>> Get()
        {
            return await context.Colors
                .Where(x => x.State == 0)
                .AsNoTracking()
                .Select(x => Color.Create(
                    x.Id,
                    x.Name,
                    x.State)
                ).ToListAsync();
        }
    }
}
