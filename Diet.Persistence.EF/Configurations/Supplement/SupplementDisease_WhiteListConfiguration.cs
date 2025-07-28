using Diet.Domain.supplementDisease_WhiteList;
using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;


public class SupplementDisease_WhiteListConfiguration : IEntityTypeConfiguration<SupplementDisease_WhiteList>
{
    public void Configure(EntityTypeBuilder<SupplementDisease_WhiteList> builder)
    {
        builder.HasKey(a => a.Id);

    }

}
