using CarDealer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs
{
    public class CountryConfig : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
