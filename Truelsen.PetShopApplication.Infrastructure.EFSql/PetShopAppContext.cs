using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // modelBuilder.Entity<Pet>().HasKey(p => new { p.PreviousOwner.OwnerId, p.})
                
            modelBuilder.Entity<Pet>().HasOne(p => p.Type).WithMany(pt => pt.PetTypePets).OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Pet>().HasMany(p => p.Colors).WithMany(pc => pc.PetColorPets);
            
            modelBuilder.Entity<Pet>().HasOne(p => p.PreviousOwner).WithMany(po => po.OwnerPets).OnDelete(DeleteBehavior.SetNull);
            
            
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        
        public DbSet<PetColor> PetColors { get; set; }
        

        
        

    }
}