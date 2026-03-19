using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations;

public class ClassTypeConfiguration : IEntityTypeConfiguration<ClassType>
{
    public void Configure(EntityTypeBuilder<ClassType> builder)
    {
        builder.ToTable("ClassTypes");
        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(ClassType.MaxLength.Name);
        builder.Property(ct => ct.Description)
            .HasMaxLength(ClassType.MaxLength.Description);
        builder.Property(ct => ct.Style)
            .HasMaxLength(ClassType.MaxLength.Style);
        builder.Property(ct => ct.Level)
            .IsRequired();
        builder.Property(ct => ct.IsActive)
            .IsRequired();

        builder.HasMany(ct => ct.QualifiedInstructors)
            .WithMany(i => i.QualifiedClassTypes)
            .UsingEntity(j => j.ToTable("InstructorClassTypes"));
    }
}
