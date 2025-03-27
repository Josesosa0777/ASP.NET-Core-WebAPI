using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = new Guid("d2d2d2d2-d2d2-d2d2-d2d2-d2d2d2d2d2d2").ToString(),  // Set a static value, to avoid generating a new value each time that the code is executed
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Id = new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3").ToString(), // Set a static value, to avoid generating a new value each time that the code is executed
                    Name = "User",
                    NormalizedName = "USER",
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}