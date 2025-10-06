using CarDealer.DataAccess.Entities.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs.Cars
{
    public class ModelConfig : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Complects).WithOne(x => x.Model).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
