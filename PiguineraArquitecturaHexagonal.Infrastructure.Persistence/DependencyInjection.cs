

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PiguineraArquitecturaHexagonal.Application.Generic;

namespace PiguineraArquitecturaHexagonal.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMongoCollection<Event>>((options) =>
            {
                var client = new MongoClient(configuration["OnlineDatabase:ConnectionString"]);
                var database = client.GetDatabase(configuration["OnlineDatabase:DatabaseName"]);
                return database.GetCollection<Event>(configuration["OnlineDatabase:UsersCollectionName"]);
            });

            services.AddScoped<IEventsRepository, EventsRepository>();

            return services;
        }
    }
}