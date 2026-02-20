using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(Instructor.MaxLength.FirstName);
        builder.Property(i => i.LastName)
            .IsRequired()
            .HasMaxLength(Instructor.MaxLength.LastName);
        builder.Property(i => i.Bio)
            .IsRequired()
            .HasMaxLength(Instructor.MaxLength.Bio);
        builder.Property(i => i.PhoneNumber)
            .IsRequired()
            .HasMaxLength(Instructor.MaxLength.PhoneNumber);
        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(Instructor.MaxLength.Email);
        builder.Property(i => i.ImageUrl)
            .HasMaxLength(200);

        var currentTime = new DateTime(2026, 2, 18, 2, 0, 0, DateTimeKind.Utc);
    }
}
