namespace Core.Models;

public class Student : BaseEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public required AppUser AppUser { get; set; }
    public string? ImageUrl { get; set; }
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
