using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Infrastructure.EFSql.Entities;

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
                
            modelBuilder.Entity<Pet>().HasOne(p => p.Type).WithMany(pt => pt.Pets).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>().HasMany(p => p.PreviousOwner).WithMany(pc => pc.Pets);

            modelBuilder.Entity<Pet>().HasMany(p => p.PreviousOwner).WithMany(po => po.Pets);
            
            
        }

        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        
        public DbSet<PetPreviousOwnerEntity> PetPreviousOwners { get; set; }
        
        public DbSet<PetPetColorEntity> PetColors { get; set; }
        
        

    }
}