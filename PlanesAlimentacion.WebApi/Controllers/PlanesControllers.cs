using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanesAlimentacion.Application.Commands.CreatePlan;
using PlanesAlimentacion.Application.Queries.GetPlanes;

namespace PlanesAlimentacion.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlanesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CrearPlan(CreatePlanCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { PlanId = id });
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerPlanes()
    {
        var planes = await _mediator.Send(new GetPlanesQuery());
        return Ok(planes);
    }

}
