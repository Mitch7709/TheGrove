namespace Core.Models;

public class TimeSlot : BaseEntity
{
    public int Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public int DurationInMinutes { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public bool IsActive { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
}

public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
