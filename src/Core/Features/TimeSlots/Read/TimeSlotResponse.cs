using TimeSlotDayOfWeek = Core.Models.DayOfWeek;

namespace Core.Features.TimeSlots.Read;

public record TimeSlotResponse(
    int Id,
    TimeOnly StartTime,
    int DurationInMinutes,
    TimeSlotDayOfWeek DayOfWeek,
    bool IsActive
);
