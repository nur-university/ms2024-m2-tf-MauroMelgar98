using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesAlimentacion.Domain.Entities;

public class Receta
{
    public Guid Id { get; private set; } = Guid.NewGuid(); // Clave primaria
    public string Nombre { get; private set; }

    public Receta(string nombre)
    {
        Nombre = nombre;
    }
}

