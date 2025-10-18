using Microsoft.EntityFrameworkCore;
using MediatR;
using PlanesAlimentacion.Application.Commands.CreatePlan;
using PlanesAlimentacion.Infrastructure.Persistence;
using PlanesAlimentacion.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreatePlanCommand).Assembly));

builder.Services.AddDbContext<PlanesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlanRepository, PlanRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();