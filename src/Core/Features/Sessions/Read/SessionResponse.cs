namespace Core.Features.Sessions.Read;

public record SessionResponse(
    int Id,
    int ClassTypeId,
    int InstructorId,
    int TimeSlotId,
    decimal Price
);
