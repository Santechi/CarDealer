using CarDealer.DataAccess.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs.Sales
{
    public class SaleConfig : IEntityTypeConfiguration<SaleEntity>
    {
        public void Configure(EntityTypeBuilder<SaleEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Car).WithMany().HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
