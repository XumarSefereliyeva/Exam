using ImtahanProyekt.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        
        public DbSet<Team> teams { get; set; }
    }
}
