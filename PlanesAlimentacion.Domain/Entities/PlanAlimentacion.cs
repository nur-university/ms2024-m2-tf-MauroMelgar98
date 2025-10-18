using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesAlimentacion.Domain.Entities;

public class PlanAlimentacion
{
    public Guid Id { get; private set; } = Guid.NewGuid(); // Clave primaria
    public int DuracionDias { get; private set; }
    public List<TiempoComida> TiemposComida { get; private set; } = new();

    public PlanAlimentacion(int duracionDias)
    {
        DuracionDias = duracionDias;
    }

    public void AgregarTiempoComida(TiempoComida tiempo)
    {
        TiemposComida.Add(tiempo);
    }
}
