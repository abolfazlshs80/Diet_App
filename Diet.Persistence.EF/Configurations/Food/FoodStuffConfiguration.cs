using Diet.Domain.food.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class FoodStuffConfiguration : IEntityTypeConfiguration<Domain.food.Entities.FoodStuff>
{
    public void Configure(EntityTypeBuilder<Domain.food.Entities.FoodStuff> builder)
    {
        builder.HasKey(builder => builder.Id);
        builder.Property(_=>_.Title).IsRequired().HasMaxLength(200);
        builder.HasMany(_ => _.CaseFoodStuffAllergy)
         .WithOne(e => e.FoodStuff)
         .HasForeignKey(_ => _.FoodStuffId)
         .OnDelete(DeleteBehavior.Restrict);

    }

}