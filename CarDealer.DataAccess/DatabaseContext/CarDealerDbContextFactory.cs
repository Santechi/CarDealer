using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.DatabaseContext
{
    public class CarDealerDbContextFactory : IDesignTimeDbContextFactory<CarDealerDbContext>
    {
        public CarDealerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealerDbContext>();

            optionsBuilder.UseNpgsql(DbConfig.GetConnectionString());

            return new CarDealerDbContext(optionsBuilder.Options);
        }
    }
}
