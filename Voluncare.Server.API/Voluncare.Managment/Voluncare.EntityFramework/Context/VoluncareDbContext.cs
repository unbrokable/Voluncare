using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Entities;

namespace Voluncare.EntityFramework.Context
{
    public class VoluncareDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public VoluncareDbContext(DbContextOptions<VoluncareDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("Server=voluncare-db.postgres.database.azure.com;Database=ValuncareTest;Port=5432;User Id=voluncare;Password=Test123123;Ssl Mode=Require;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VoluncareDbContext).Assembly);
        }
    }
}
