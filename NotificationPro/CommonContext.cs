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
        public CommonContext() : base(new DbContextOptionsBuilder<CommonContext>()
            .UseSqlServer("Data Source=HOST\\SQLEXPRESS;Initial Catalog=NotificationPro;User ID=test;Password=test;MultipleActiveResultSets=True")
            .Options) { }
        public CommonContext(DbContextOptions<CommonContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
            public DbSet<Link> Links { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(x => x.Id);
                    entity.HasMany(x => x.Links);
                });

                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Link>(entity =>
                {
                    entity.HasKey(x => x.Id);
                });
                
            }
        }
}
