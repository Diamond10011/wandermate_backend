using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wandermate.Models;

namespace wandermate.Interface
{
    public interface ITokenService
    {
        string CreateToken (AppUser user);
    }
}