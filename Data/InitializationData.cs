using Microsoft.AspNetCore.Identity;
using Personnel_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personnel_Service.Data
{
    public class InitializationData
    {
        public class Role
        {
            public string Id;
            public string Name;
            public string Description;
        }

        private static List<Role> roles = new List<Role>()
        {
            new Role(){
                Name = "Admin",
                Description = "Admin role"
            },
            new Role(){
                Name = "Manager",
                Description = "Manager role"
            },
            new Role(){
                Name = "Coordinator",
                Description = "Coordinator role"
            },
        };

        public static async Task Initialize(Personnel_ServiceContext context, RoleManager<AccountRole> roleManager, UserManager<AccountUser> userManager)
        {
            context.Database.EnsureCreated();

            foreach (var role in roles)
            {
                if(await roleManager.FindByNameAsync(role.Name) == null)
                {
                    await roleManager.CreateAsync(new AccountRole(role.Name, role.Description, DateTime.Now));
                }
            }  
            
            if(await userManager.FindByNameAsync("admin") == null)
            {
                var user = new AccountUser() { UserName = "admin" };
                var result = await userManager.CreateAsync(user, "admin");
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
