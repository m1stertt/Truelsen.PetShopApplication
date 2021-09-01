using System;
using Microsoft.Extensions.DependencyInjection;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Domain.IRepositories;
using Truelsen.PetShopApplication.Domain.Services;
using Truelsen.PetShopApplication.Infrastructure.DataAccess.Repositories;

namespace Truelsen.PetShopApplication.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepositoryMemory>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepositoryInMemory>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var petTypeService = serviceProvider.GetRequiredService<IPetTypeService>();
            var menu = new Menu(petService, petTypeService);
            menu.Start();
        }
    }
}