using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Domain.IRepositories;
using Truelsen.PetShopApplication.Domain.Services;
using Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories;

namespace Truelsen.PetShopApplication.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Truelsen.PetShopApplication.PetRestAPI", Version = "v1"});
            });
            services.AddScoped<IPetRepository, PetRepositoryMemory>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepositoryInMemory>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IOwnerRepository, OwnerRepositoryInMemory>();
            services.AddScoped<IOwnerService, OwnerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Truelsen.PetShopApplication.PetRestAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}