using Azure.CachedStorage.Entities;
using Azure.CachedStorage.Entities.DataWriter;
using Azure.CachedStorage.Entities.DataWriter.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.CachedStorage.Demo
{
    public static class ServiceExtensions
    {
        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            
            //services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(connectionString);

        
            // Database settings for Data writer

            //DbContextOptionsBuilder builder = new DbContextOptionsBuilder<FlightsDBContext>();
            //builder.UseSqlServer(config.GetConnectionString("myconn"));

            
            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));

            //services.AddDbContext<RepositoryContext>(builder.Options);

        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
