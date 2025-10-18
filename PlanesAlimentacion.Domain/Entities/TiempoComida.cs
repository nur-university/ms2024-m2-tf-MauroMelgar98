using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesAlimentacion.Domain.Entities;

public class TiempoComida
{
    public Guid Id { get; private set; } = Guid.NewGuid(); // Clave primaria
    public string Nombre { get; private set; }
    public List<Receta> Recetas { get; private set; } = new();

    public TiempoComida(string nombre)
    {
        Nombre = nombre;
    }

    public void AsignarReceta(Receta receta)
    {
        Recetas.Add(receta);
    }
}
