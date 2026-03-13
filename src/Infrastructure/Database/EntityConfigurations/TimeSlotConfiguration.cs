using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Database.EntityConfigurations;

public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.ToTable("TimeSlots");
        builder.HasKey(ts => ts.Id);
        builder.Property(ts => ts.StartTime)
            .IsRequired();
        builder.Property(ts => ts.DurationInMinutes)
            .IsRequired();
        builder.Property(ts => ts.DayOfWeek)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(ts => ts.IsActive)
            .IsRequired();
    }
}
