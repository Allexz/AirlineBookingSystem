using AirlineBooking.System.Flights.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Flights.Infrastructure.Data;
public class FlightContext : IFlightContext
{
    public IMongoCollection<Flight> Flights { get; }

    public FlightContext(IConfiguration configuration)
    {
        var cliente = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var database = cliente.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        Flights = database.GetCollection<Flight>(configuration["DatabaseSettings:CollectionName"]);
    }
}
