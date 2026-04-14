using Core.Features.ClassTypes.Read;
using System;
using System.Collections.Generic;

namespace Core.Features.ClassTypes.Update;

public record UpdateClassTypeRequest(
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive,
    IReadOnlyList<int> QualifiedInstructorIds
);

public record UpdateClassTypeResponse(
    int Id,
    string Name,
    string Description,
    string Style,
    int Level,
    bool IsActive,
    IReadOnlyList<QualifiedInstructorSummary> QualifiedInstructors
);
