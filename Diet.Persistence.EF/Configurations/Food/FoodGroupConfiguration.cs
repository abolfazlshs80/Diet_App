using Diet.Domain.food.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class FoodGroupConfiguration : IEntityTypeConfiguration<FoodGroup>
{
    public void Configure(EntityTypeBuilder<FoodGroup> builder)
    {

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Title).IsRequired().HasMaxLength(200);
        builder.HasMany(_ => _.Food)
                 .WithOne(e => e.FoodGroup)
                 .HasForeignKey(_ => _.FoodGroupId)
                 .OnDelete(DeleteBehavior.Restrict);
    }

}
