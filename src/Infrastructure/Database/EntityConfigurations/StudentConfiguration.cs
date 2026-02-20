using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(Student.MaxLength.FirstName);
        builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(Student.MaxLength.LastName);
        builder.Property(s => s.Age)
            .IsRequired();
        builder.Property(s => s.DateOfBirth)
            .IsRequired();
        builder.Property(s => s.PhoneNumber)
            .IsRequired()
            .HasMaxLength(Student.MaxLength.PhoneNumber);
        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(Student.MaxLength.Email);
        builder.Property(s => s.ImageUrl)
            .HasMaxLength(200);
        builder.Property(s => s.WaiverStatus)
            .IsRequired()
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.HasMany(s => s.Bookings)
            .WithOne(b => b.Student)
            .HasForeignKey(b => b.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

            var currentTime = new DateTime(2026, 2, 18, 2, 0, 0, DateTimeKind.Utc);
    }
}
