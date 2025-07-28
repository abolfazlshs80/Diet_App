using Diet.Domain.ticket;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diet.Persistence.EF.Configurations.User;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> entity)
    {

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(300);

        entity.Property(e => e.Number)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.Priority)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.Status)
              .HasConversion<int>()
              .IsRequired();

        entity.Property(e => e.UserId)
              .IsRequired();

        entity.HasMany(e => e.Messages)
              .WithOne(m => m.Ticket)
              .HasForeignKey(m => m.TicketId);

        entity.HasOne(e => e.User)
              .WithMany(_=>_.Ticket) // اگر Case دارای مجموعه‌ای از Ticket باشه، اینجا مشخص کن
              .HasForeignKey(e => e.UserId)
              .OnDelete(DeleteBehavior.SetNull); // چون CaseId nullable هست
    }

}

