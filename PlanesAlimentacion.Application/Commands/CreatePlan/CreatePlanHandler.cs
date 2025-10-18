using MediatR;
using PlanesAlimentacion.Domain.Entities;
using PlanesAlimentacion.Domain.Repositories;

namespace PlanesAlimentacion.Application.Commands.CreatePlan;

public class CreatePlanHandler : IRequestHandler<CreatePlanCommand, Guid>
{
    private readonly IPlanRepository _repo;

    public CreatePlanHandler(IPlanRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = new PlanAlimentacion(request.DuracionDias);
        foreach (var tiempoDto in request.TiemposComida)
        {
            var tiempo = new TiempoComida(tiempoDto.Nombre);
            foreach (var recetaNombre in tiempoDto.Recetas)
            {
                tiempo.AsignarReceta(new Receta(recetaNombre));
            }
            plan.AgregarTiempoComida(tiempo);
        }

        await _repo.GuardarAsync(plan);
        return plan.Id;
    }
}
