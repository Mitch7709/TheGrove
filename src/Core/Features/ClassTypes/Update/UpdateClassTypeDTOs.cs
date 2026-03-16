using System;

namespace Core.Features.ClassTypes.Update;

public record UpdateClassTypeRequest(
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive
);

public record UpdateClassTypeResponse(
    int Id,
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive
);
