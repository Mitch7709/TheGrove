using Core.Models;

namespace Core.Features.Sessions.Read;

public record SessionResponse(
    int Id,
    ClassTypeSummary ClassType,
    InstructorSummary Instructor,
    TimeSlotSummary TimeSlot,
    decimal Price,
    DateOnly SessionDate,
    SessionStatus Status
);

public record ClassTypeSummary(int Id, string Name, string Style, int Level);
public record InstructorSummary(int Id, string Name);
public record TimeSlotSummary(int Id, DayOfWeek DayOfWeek, TimeOnly StartTime, int DurationInMinutes);
