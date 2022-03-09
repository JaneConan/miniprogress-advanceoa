using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using aspnetapp;

namespace aspnetapp
{
    public partial class CounterContext : DbContext
    {
        public CounterContext()
        {
        }
        public DbSet<Counter> Counters { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<ApletUser> ApletUsers { get; set; } = null!;

        public CounterContext(DbContextOptions<CounterContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = "workpc";
                var password = "Qn%G5deZ";
                var addressParts = "sh-cynosdbmysql-grp-1wxhc5so.sql.tencentcdb.com:22189".Split(':');
                var host = addressParts?[0];
                var port = addressParts?[1];
                var connstr = $"server={host};port={port};user={username};password={password};database=aspnet_demo";
                optionsBuilder.UseMySql(connstr, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Counter>().ToTable("Counters");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<ApletUser>().ToTable("ApletUsers");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
