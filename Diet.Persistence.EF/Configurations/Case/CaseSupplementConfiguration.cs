using Diet.Domain.caseSupplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class CaseSupplementConfiguration : IEntityTypeConfiguration<CaseSupplement>
{
    public void Configure(EntityTypeBuilder<CaseSupplement> builder)
    {

        builder.HasKey(x => x.Id);
    }

}
