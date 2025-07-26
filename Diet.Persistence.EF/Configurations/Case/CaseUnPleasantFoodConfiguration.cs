using Diet.Domain.caseUnPleasantFood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CaseUnPleasantFoodConfiguration : IEntityTypeConfiguration<CaseUnPleasantFood>
{
    public void Configure(EntityTypeBuilder<CaseUnPleasantFood> builder)
    {

        builder.HasKey(x => x.Id);
    }

}
