using System.Text.Json.Serialization;

namespace Core.Models;

public class TimeSlot : BaseEntity
{
    public int Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public int DurationInMinutes { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public bool IsActive { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
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
