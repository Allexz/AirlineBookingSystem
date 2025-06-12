using AirlineBookingSystem.Bookings.Api.Models;
using AirlineBookingSystem.Bookings.Application.Consumers;
using AirlineBookingSystem.Bookings.Application.Handlers;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.Bookings.Infrastructure.Repositories;
using AirlineBookingSystem.BuildingBlocks.Common;
using MassTransit;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
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
    typeof(CreateBookingHandler).Assembly,
    typeof(GetBookingHandler).Assembly
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Bind da configuração do Redis
builder.Services.Configure<CacheSettings>(
    builder.Configuration.GetSection("CacheSettings"));

// Registrar o ConnectionMultiplexer como singleton
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = sp.GetRequiredService<IOptions<CacheSettings>>().Value;

    var options = ConfigurationOptions.Parse(config.ConnectionString);
    options.Password = config.Password;
    options.AllowAdmin = true;

    return ConnectionMultiplexer.Connect(options);
});

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<NotificationEventConsumer>();
    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.NotificationSentQueue, e =>
        {
            e.ConfigureConsumer<NotificationEventConsumer>(ct);
        });
    });
});


 

var app = builder.Build();

// Configure the HTTP request pipeline.

// Always enable OpenAPI/Swagger UI

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
