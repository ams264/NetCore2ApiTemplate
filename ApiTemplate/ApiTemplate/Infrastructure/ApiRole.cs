using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ApiTemplate.Infrastructure
{
    public class ApiRole: IdentityRole<Guid>
    {
        public ApiRole(): base()
        {
            
        }

        public ApiRole(string roleName)
        {
            Name = roleName;
        }
    }
}
