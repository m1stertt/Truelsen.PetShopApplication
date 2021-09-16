using Microsoft.EntityFrameworkCore;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql
{
    public class PetShopAppContext : DbContext
    {
        protected PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owner { get; set; }
        
    }
}