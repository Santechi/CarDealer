using CarDealer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs
{
    public class BrandConfig : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
