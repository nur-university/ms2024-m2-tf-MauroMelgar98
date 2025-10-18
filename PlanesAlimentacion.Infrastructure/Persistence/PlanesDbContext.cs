using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanesAlimentacion.Domain.Entities;

namespace PlanesAlimentacion.Infrastructure.Persistence;

public class PlanesDbContext : DbContext
{
    public DbSet<PlanAlimentacion> Planes { get; set; }

    public PlanesDbContext(DbContextOptions<PlanesDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanAlimentacion>().HasKey(p => p.Id);
        modelBuilder.Entity<TiempoComida>().HasKey(t => t.Id);
        modelBuilder.Entity<Receta>().HasKey(r => r.Id);

        modelBuilder.Entity<PlanAlimentacion>()
            .HasMany(p => p.TiemposComida)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TiempoComida>()
            .HasMany(t => t.Recetas)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}