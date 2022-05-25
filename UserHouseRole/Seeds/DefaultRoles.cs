﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserHouseRole.Constants;

namespace UserHouseRole.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}