using System;
using System.Linq;
using System.Reflection;

using AutoMapper;

using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ReadCache.App
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            this.env = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediatR();
            services.AddMvc();

            if (!env.IsDevelopment())
            {
                services.Configure<MvcOptions>(o => o.Filters.Add(new RequireHttpsAttribute()));
            }

            // Database settings for Data writer
            //services.AddDbContext<RepositoryContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
