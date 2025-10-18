using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PlanesAlimentacion.Application.Queries.GetPlanes;

public class GetPlanesQuery : IRequest<List<PlanDto>> { }

public class PlanDto
{
    public Guid Id { get; set; }
    public int DuracionDias { get; set; }
    public List<TiempoComidaDto> TiemposComida { get; set; }
}

public class TiempoComidaDto
{
    public string Nombre { get; set; }
    public List<string> Recetas { get; set; }
}

