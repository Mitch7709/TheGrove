using System;

namespace Core.Features.ClassTypes.Create;

public record CreateClassTypeRequest(
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive
);

public record CreateClassTypeResponse(
    int Id,
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive
);
