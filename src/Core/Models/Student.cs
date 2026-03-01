using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Student : BaseEntity
{
    public static class MaxLength
    {
        public const int FirstName = 50;
        public const int LastName = 50;
        public const int PhoneNumber = 20;
        public const int Email = 100;
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;    
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public WaiverStatus WaiverStatus { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public int CalculateAge()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth > today.AddYears(-age))
            age--;
        return age;
    }
}

public enum WaiverStatus
{
    NotSigned,
    Signed,
    Expired
}
