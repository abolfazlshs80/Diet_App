using Diet.Domain.food.Entities;

using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class FoodConfiguration : IEntityTypeConfiguration<Domain.food.Entities.Food>
{
    public void Configure(EntityTypeBuilder<Domain.food.Entities.Food> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .HasMaxLength(200);

        entity.Property(e => e.Description)
              .HasMaxLength(1000);

        entity.Property(e => e.Value)
              .HasColumnType("float"); // یا double بسته به دیتابیس

        // رابطه با FoodGroup (Many-to-One)
        entity.HasOne(e => e.FoodGroup)
              .WithMany(g => g.Food) // باید در FoodGroup تعریف شده باشد
              .HasForeignKey(e => e.FoodGroupId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(_ => _.FoodFirst)
            .WithOne(e => e.FoodFirst)
            .HasForeignKey(_ => _.FoodFistId)
            .OnDelete(DeleteBehavior.Restrict);


        entity.HasMany(_ => _.FoodSecond)
            .WithOne(e => e.FoodSecond)
            .HasForeignKey(_ => _.FoodSecondId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(_ => _.CaseUnPleasantFood)
            .WithOne(e => e.Food)
            .HasForeignKey(_ => _.FoodId)
            .OnDelete(DeleteBehavior.Restrict);


        entity.HasMany(_ => _.CasePleasantFood)
            .WithOne(e => e.Food)
            .HasForeignKey(_ => _.FoodId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(_ => _.Food_Drug_Intraction)
          .WithOne(e => e.Food)
          .HasForeignKey(_ => _.FoodId)
          .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(_ => _.FoodGroup)
         .WithMany(e => e.Food)
         .HasForeignKey(_ => _.FoodGroupId)
         .OnDelete(DeleteBehavior.Restrict);

    }

}
