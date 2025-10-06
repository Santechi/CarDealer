using CarDealer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.DataAccess.Configs
{
    public class ComplectConfig : IEntityTypeConfiguration<ComplectEntity>
    {
        public void Configure(EntityTypeBuilder<ComplectEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Model).WithMany(x => x.Complects).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
