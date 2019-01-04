using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationPro.Entities;
using Microsoft.EntityFrameworkCore;

namespace NotificationPro
{
    
        public class CommonContext : DbContext
        {
            public CommonContext(DbContextOptions<CommonContext> options) : base(options) { }

            public DbSet<User> UserDbSet { get; set; }
            public DbSet<Link> LinksDbSet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(x => x.Name);
                });

                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Link>(entity =>
                {
                    entity.HasKey(x => x.Url);
                });

        }
        }
}
