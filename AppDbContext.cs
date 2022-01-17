using System;
using Microsoft.EntityFrameworkCore;

namespace DAEntity
{
    public class AppDbContext : DbContext
    {

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Metrica> Metricas { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<MetricaLinea> MetricasLineas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.EnableSensitiveDataLogging();

            var conn = @"Data Source=appdb.db";
            optionsBuilder.UseSqlite(conn);
            // .LogTo(x => Console.WriteLine(x));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // auto-include navigational properties
            modelBuilder.Entity<BlogPost>().Navigation(x => x.Author).AutoInclude();

            modelBuilder.Entity<Linea>()
            .HasMany(m => m.Metricas)
            .WithMany(m => m.Lineas)
            .UsingEntity<MetricaLinea>(
                b => b
                    .HasOne(pt => pt.Metrica)
                    .WithMany(t => t.MetricaLineas)
                    .HasForeignKey(pt => pt.MetricaId),
                b => b
                    .HasOne(pt => pt.Linea)
                    .WithMany(p => p.MetricaLineas)
                    .HasForeignKey(pt => pt.LineaId),
                b =>
                {
                    b.HasKey(b => new { b.LineaId, b.MetricaId });
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}