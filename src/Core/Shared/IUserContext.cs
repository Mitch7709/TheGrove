using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared;

public interface IUserContext
{
    bool IsAuthenticated();
    string? GetUserId();
}
