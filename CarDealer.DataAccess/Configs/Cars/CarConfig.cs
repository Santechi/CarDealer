using CarDealer.DataAccess.Entities.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs.Cars
{
    public class CarConfig : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Complect).WithMany().HasForeignKey(x => x.ComplectId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Color).WithMany().HasForeignKey(x => x.ColorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
