using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using PlanesAlimentacion.Application.Queries.GetPlanes;
using PlanesAlimentacion.Domain.Repositories;

namespace PlanesAlimentacion.Application.Queries.GetPlanes;

public class GetPlanesHandler : IRequestHandler<GetPlanesQuery, List<PlanDto>>
{
    private readonly IPlanRepository _repo;

    public GetPlanesHandler(IPlanRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<PlanDto>> Handle(GetPlanesQuery request, CancellationToken cancellationToken)
    {
        var planes = await _repo.ObtenerTodosAsync();

        return planes.Select(p => new PlanDto
        {
            Id = p.Id,
            DuracionDias = p.DuracionDias,
            TiemposComida = p.TiemposComida.Select(t => new TiempoComidaDto
            {
                Nombre = t.Nombre,
                Recetas = t.Recetas.Select(r => r.Nombre).ToList()
            }).ToList()
        }).ToList();
    }
}

