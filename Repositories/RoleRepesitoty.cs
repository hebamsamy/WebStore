using EcommerceDB.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RoleRepesitoty:MainRepository<IdentityRole>
    {
        RoleManager<IdentityRole> roleManager;
        public RoleRepesitoty(EcommerceDBContext dBContext, RoleManager<IdentityRole> _roleManager) :base(dBContext)
        {
            roleManager = _roleManager;

        }

        public async Task<IdentityResult> Add(string rolename)
        {
            return await roleManager.CreateAsync(new IdentityRole { Name = rolename });
        }
    }
}
