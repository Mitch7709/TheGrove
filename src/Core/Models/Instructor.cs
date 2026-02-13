using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Instructor : BaseEntity
{
    public static class MaxLength
    {
        public const int FirstName = 50;
        public const int LastName = 50;
        public const int Bio = 500;
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
