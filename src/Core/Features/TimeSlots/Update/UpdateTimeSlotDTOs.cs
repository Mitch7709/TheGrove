using TimeSlotDayOfWeek = Core.Models.DayOfWeek;

namespace Core.Features.TimeSlots.Update;

public record UpdateTimeSlotRequest(
    TimeOnly StartTime,
    int DurationInMinutes,
    TimeSlotDayOfWeek DayOfWeek,
    bool IsActive
);

public record UpdateTimeSlotResponse(
    int Id,
    TimeOnly StartTime,
    int DurationInMinutes,
    TimeSlotDayOfWeek DayOfWeek,
    bool IsActive
);
