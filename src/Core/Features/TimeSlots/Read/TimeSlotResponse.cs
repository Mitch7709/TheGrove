namespace Core.Features.TimeSlots.Read;

public record TimeSlotResponse(
    int Id,
    TimeOnly StartTime,
    int DurationInMinutes,
    DayOfWeek DayOfWeek,
    bool IsActive
);
