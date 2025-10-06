using CarDealer.DataAccess.Entities.Cars;
using CarDealer.DataAccess.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.DatabaseContext
{
    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options) : base(options)
        {
        }

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<ComplectEntity> Complects { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ModelEntity> Models { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}