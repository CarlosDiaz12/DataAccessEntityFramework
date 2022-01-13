using System;
using Microsoft.EntityFrameworkCore;

namespace DAEntity
{
    public class AppDbContext : DbContext
    {

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            var conn = @"Data Source=appdb.db";
            optionsBuilder.UseSqlite(conn);
            // .LogTo(x => Console.WriteLine(x));
            base.OnConfiguring(optionsBuilder);
        }

    }
}