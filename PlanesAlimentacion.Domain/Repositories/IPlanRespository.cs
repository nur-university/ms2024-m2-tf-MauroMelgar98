using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanesAlimentacion.Domain.Entities;

namespace PlanesAlimentacion.Domain.Repositories;

public interface IPlanRepository
{
    Task GuardarAsync(PlanAlimentacion plan);
    Task<List<PlanAlimentacion>> ObtenerTodosAsync();

}

