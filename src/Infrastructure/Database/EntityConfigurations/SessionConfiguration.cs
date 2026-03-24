using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.HasOne(s => s.ClassType)
            .WithMany()
            .HasForeignKey(s => s.ClassTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.Instructor)
            .WithMany()
            .HasForeignKey(s => s.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.TimeSlot)
            .WithMany()
            .HasForeignKey(s => s.TimeSlotId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Bookings)
            .WithOne(b => b.Session)
            .HasForeignKey(b => b.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
