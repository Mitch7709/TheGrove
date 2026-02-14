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
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public WaiverStatus WaiverStatus { get; set; }
}

public enum WaiverStatus
{
    NotSigned,
    Signed,
    Expired
}
