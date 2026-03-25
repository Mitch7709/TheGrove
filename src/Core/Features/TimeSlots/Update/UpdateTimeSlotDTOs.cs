
namespace Core.Features.TimeSlots.Update;

public record UpdateTimeSlotRequest(
    TimeOnly StartTime,
    int DurationInMinutes,
    string DayOfWeek,
    bool IsActive
);

public record UpdateTimeSlotResponse(
    int Id,
    TimeOnly StartTime,
    int DurationInMinutes,
    DayOfWeek DayOfWeek,
    bool IsActive
);
