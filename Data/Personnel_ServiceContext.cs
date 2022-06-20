using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Personnel_Service.Models;

namespace Personnel_Service.Data
{
    public class Personnel_ServiceContext : IdentityDbContext<AccountUser, AccountRole, string>
    {
        public Personnel_ServiceContext (DbContextOptions<Personnel_ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Personnel_Service.Models.Worker> Worker { get; set; }

        public DbSet<Personnel_Service.Models.Room> Room { get; set; }

        public DbSet<Personnel_Service.Models.RoomConnection> RoomConnection { get; set; }
    }
}
