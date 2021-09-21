using System;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql
{
    public class DBInitializor
    {
        public static void SeedDb(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var petType1 = ctx.PetTypes.Add(new PetType()
            {
            Name = "Goat"
            }).Entity;
            
            var petType2 = ctx.PetTypes.Add(new PetType()
            {
                Name = "Dog"
            }).Entity;

            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Peter",
                LastName = "Hansen",
            }).Entity;
            
            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Jacob",
                LastName = "Larsen",
            }).Entity;

            Pet pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Luffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 5000,
                Type = petType1,
                SoldDate = DateTime.Now,
                PreviousOwner = owner1

            }).Entity;

            Pet pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Vuffi",
                Birthdate = DateTime.Now,
                Color = "White",
                Price = 150000,
                Type = petType1,
                SoldDate = DateTime.Now,
                PreviousOwner = owner1

            }).Entity;

            Pet pet3 = ctx.Pets.Add(new Pet()
            {
                Name = "Buffi",
                Birthdate = DateTime.Now,
                Color = "Gray",
                Price = 25000,
                Type = petType2,
                SoldDate = DateTime.Now,
                PreviousOwner = owner2

            }).Entity;

            Pet pet4 = ctx.Pets.Add(new Pet()
            {
                Name = "Muffi",
                Birthdate = DateTime.Now,
                Color = "Black",
                Price = 100000,
                Type = petType2,
                SoldDate = DateTime.Now,
                PreviousOwner = owner2

            }).Entity;
            ctx.SaveChanges();
        }
    }
}