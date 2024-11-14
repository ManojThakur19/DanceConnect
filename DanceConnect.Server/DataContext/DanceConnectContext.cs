using DanceConnect.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DanceConnect.Server.DataContext
{
    public class DanceConnectContext : IdentityDbContext<ApplicationUser>
    {
        public DanceConnectContext(DbContextOptions<DanceConnectContext> options): base(options){ }
    }
}
