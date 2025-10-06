using CarDealer.DataAccess.Entities.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs.Cars
{
    public class ColorConfig : IEntityTypeConfiguration<ColorEntity>
    {
        public void Configure(EntityTypeBuilder<ColorEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
