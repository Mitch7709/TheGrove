using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
            (
                new IdentityRole
                {
                    Id = "d4a1c57e-5f2b-4e3a-9c8d-1a2b3c4d5e6f",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = null
                },
                new IdentityRole
                {
                    Id = "a7b8c9d0-1e2f-3a4b-5c6d-7e8f9a0b1c2d",
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR",
                    ConcurrencyStamp = null
                },
                new IdentityRole
                {
                    Id = "f1e2d3c4-b5a6-7890-abcd-ef1234567890",
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = null
                }
            );
        }
    }
}
