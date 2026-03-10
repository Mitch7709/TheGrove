using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Features.Users;

public interface ITokenService
{
    Task<string> GenerateToken(AppUser user);
}
