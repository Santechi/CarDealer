using CarDealer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs
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
