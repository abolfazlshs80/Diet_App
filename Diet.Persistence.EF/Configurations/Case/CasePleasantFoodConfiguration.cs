using Diet.Domain.casePleasantFood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CasePleasantFoodConfiguration : IEntityTypeConfiguration<CasePleasantFood>
{
    public void Configure(EntityTypeBuilder<CasePleasantFood> builder)
    {

        builder.HasKey(x => x.Id);
    }

}
