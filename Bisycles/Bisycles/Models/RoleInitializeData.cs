using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class RoleInitializeData
    {
        public static void Initialize(UserContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new IdentityRole
                    {
                        Name = "guest",
                        NormalizedName = "GUEST"
                    },
                    new IdentityRole
                    { 
                        Name = "super admin",
                        NormalizedName = "SUPER ADMIN"
                    });
                context.SaveChanges();
            }
        }
    }
}
