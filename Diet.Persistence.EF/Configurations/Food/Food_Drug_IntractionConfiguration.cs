using Diet.Domain.food.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class Food_Drug_IntractionConfiguration : IEntityTypeConfiguration<Food_Drug_Intraction>
{
    public void Configure(EntityTypeBuilder<Food_Drug_Intraction> builder)
    {

        builder.HasKey(d => d.Id);
    }

}
