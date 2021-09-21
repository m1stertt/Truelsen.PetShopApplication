using Microsoft.EntityFrameworkCore;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

    }
}