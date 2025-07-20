using Diet.Domain.user.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class UserConfiguration : IEntityTypeConfiguration<Domain.user.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.user.Entities.User> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.FirstName)
              .HasMaxLength(100);

        entity.Property(e => e.LastName)
              .HasMaxLength(100);

        entity.Property(e => e.ImageName)
              .HasMaxLength(255);

        entity.Property(e => e.ReferenceCode)
              .HasMaxLength(50);

        entity.Property(e => e.VerifyCode)
              .HasMaxLength(20);

        entity.Property(e => e.CardNumber)
              .HasMaxLength(16);

        entity.Property(e => e.ShbaNumber)
              .HasMaxLength(26);

        entity.Property(e => e.Deleted)
              .IsRequired();

        entity.Property(e => e.CreateDate)
              .IsRequired();

        entity.Property(e => e.BirthDay);

        entity.Property(e => e.VerifyExpire);

        entity.Property(e => e.Gender)
              .HasConversion<int>()  // ذخیره enum به صورت int
              .IsRequired(false);    // چون nullable تعریف شده

        // One-to-Many: User → Ticket
        entity.HasMany(e => e.Ticket)
              .WithOne(t => t.User)
              .HasForeignKey(t => t.UserId)
              .OnDelete(DeleteBehavior.Restrict);

        // One-to-Many: User → TicketMessage (فرستنده)
        entity.HasMany(e => e.FormTicketMessage)
              .WithOne(tm => tm.FromUser)
              .HasForeignKey(tm => tm.FromId)
              .OnDelete(DeleteBehavior.Restrict);

        // One-to-Many: User → Case
        entity.HasMany(e => e.Case)
              .WithOne(c => c.User)
              .HasForeignKey(c => c.UserId)
              .OnDelete(DeleteBehavior.Cascade);

        // Many-to-Many: User <-> Role (via UserRole)
        entity.HasMany(e => e.UserRoles)
              .WithOne(ur => ur.User)
              .HasForeignKey(ur => ur.UserId)
              .OnDelete(DeleteBehavior.Cascade);


    }

}

public class UserRoleConfiguration : IEntityTypeConfiguration<Domain.user.Entities.UserRole>
{
    public void Configure(EntityTypeBuilder<Domain.user.Entities.UserRole> builder)
    {

        builder.HasKey(_ => _.Id);
    }

}
