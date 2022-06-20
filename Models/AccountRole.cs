using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personnel_Service.Models
{
    public class AccountRole : IdentityRole
    {
        public AccountRole() : base()
        {
        }

        public AccountRole(string roleName) : base(roleName)
        {
        }

        public AccountRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            Description = description;
            CreationDate = creationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
