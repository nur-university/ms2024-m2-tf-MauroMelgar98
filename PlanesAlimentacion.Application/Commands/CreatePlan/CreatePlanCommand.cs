using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PlanesAlimentacion.Application.Commands.CreatePlan;

public class CreatePlanCommand : IRequest<Guid>
{
    public int DuracionDias { get; set; }
    public List<TiempoComidaDto> TiemposComida { get; set; }
}

public class TiempoComidaDto
{
    public string Nombre { get; set; }
    public List<string> Recetas { get; set; }
}
