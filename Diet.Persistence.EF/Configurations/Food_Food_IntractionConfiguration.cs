using Diet.Domain.food.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.EF.Configurations;

public class Food_Food_IntractionConfiguration : IEntityTypeConfiguration<Food_Food_Intraction>
{
    public void Configure(EntityTypeBuilder<Food_Food_Intraction> builder)
    {
        builder.HasOne(a=>a.FoodFirst).WithMany(b=>b.FoodFirst).HasForeignKey(a=>a.FoodFistId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a=>a.FoodSecond).WithMany(b=>b.FoodSecond).HasForeignKey(a=>a.FoodSecondId).OnDelete(DeleteBehavior.Restrict);
        
    }

}
