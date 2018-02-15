using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure
{
    public class ApiContext : IdentityDbContext<ApiUser, ApiRole, Guid>
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Define Guid primary key for identity user
            base.OnModelCreating(builder);
            
            //Use guid as primary key
            builder.Entity<ApiUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            //Use int as primary key
            //builder.Entity<ApiUser>().Property(p => p.Id).UseSqlServerIdentityColumn();

            builder.Entity<Item>().ToTable("Item");
        }

    }
}
