namespace Core.Features.Sessions.Update;

public record UpdateSessionRequest(
    int ClassTypeId,
    int InstructorId,
    int TimeSlotId,
    decimal Price
);

public record UpdateSessionResponse(
    int Id,
    int ClassTypeId,
    int InstructorId,
    int TimeSlotId,
    decimal Price
);
