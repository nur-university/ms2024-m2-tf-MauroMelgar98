using Microsoft.EntityFrameworkCore;
using PlanesAlimentacion.Domain.Entities;
using PlanesAlimentacion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesAlimentacion.Infrastructure.Persistence;

public class PlanRepository : IPlanRepository
{
    private readonly PlanesDbContext _context;

    public PlanRepository(PlanesDbContext context)
    {
        _context = context;
    }

    public async Task GuardarAsync(PlanAlimentacion plan)
    {
        _context.Planes.Add(plan);
        await _context.SaveChangesAsync();
    }
    public async Task<List<PlanAlimentacion>> ObtenerTodosAsync()
    {
        return await _context.Planes
            .Include(p => p.TiemposComida)
            .ThenInclude(t => t.Recetas)
            .ToListAsync();
    }

}

