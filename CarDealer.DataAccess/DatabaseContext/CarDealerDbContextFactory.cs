using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarDealer.DataAccess.DatabaseContext
{
    public class CarDealerDbContextFactory : IDesignTimeDbContextFactory<CarDealerDbContext>
    {
        public CarDealerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            var connectionString = configuration.GetConnectionString(nameof(CarDealerDbContext));

            var optionsBuilder = new DbContextOptionsBuilder<CarDealerDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return new CarDealerDbContext(optionsBuilder.Options);
        }
    }
}
