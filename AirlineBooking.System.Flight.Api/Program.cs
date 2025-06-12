using AirlineBooking.System.Flights.Application.Handlers;
using AirlineBooking.System.Flights.Core.Entities;
using AirlineBooking.System.Flights.Infrastructure.Data;
using AirlineBooking.System.Flights.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateFlightHandler).Assembly,
    typeof(GetAllFlightHandler).Assembly,
    typeof(DeleteFlightHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
builder.Services.AddScoped<IFlightContext, FlightContext>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
