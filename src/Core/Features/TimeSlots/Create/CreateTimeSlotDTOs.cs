using TimeSlotDayOfWeek = Core.Models.DayOfWeek;

namespace Core.Features.TimeSlots.Create;

public record CreateTimeSlotRequest(
    TimeOnly StartTime,
    int DurationInMinutes,
    TimeSlotDayOfWeek DayOfWeek,
    bool IsActive
);

public record CreateTimeSlotResponse(
    int Id,
    TimeOnly StartTime,
    int DurationInMinutes,
    TimeSlotDayOfWeek DayOfWeek,
    bool IsActive
);
