using AirlineBooking.System.Notifications.Application.Consumers;
using AirlineBooking.System.Notifications.Application.Handlers;
using AirlineBooking.System.Notifications.Application.Interfaces;
using AirlineBooking.System.Notifications.Application.Services;
using AirlineBooking.System.Notifications.Core.Repositories;
using AirlineBooking.System.Notifications.Infrastructure.Repositories;
using AirlineBookingSystem.BuildingBlocks.Common;
using MassTransit;
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
    typeof(SendNotificationHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
builder.Services.AddScoped<INotificationServices, NotificationServices>();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<PaymentProcessedConsumer>();
    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.PaymentProcessedQueue, e =>
        {
            e.ConfigureConsumer<PaymentProcessedConsumer>(ct);
        });
    });
});


builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
