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

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IPetService>();
            var menu = new Menu(service);
            menu.Start();
        }
    }
}