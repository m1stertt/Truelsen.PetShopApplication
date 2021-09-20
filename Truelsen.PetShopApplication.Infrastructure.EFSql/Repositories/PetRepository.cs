using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }


        public Pet Add(Pet pet)
        {
            var savedPet = new Pet()
            {
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Color = pet.Color,
                Price = pet.Price,
                Type = pet.Type,
                PreviousOwner = pet.PreviousOwner,
                SoldDate = pet.SoldDate
            };
            return new Pet()
            {
                Id = savedPet.Id,
                Name = savedPet.Name,
                Birthdate = savedPet.Birthdate,
                Color = savedPet.Color,
                Price = savedPet.Price,
                Type = savedPet.Type,
                PreviousOwner = savedPet.PreviousOwner,
                SoldDate = savedPet.SoldDate
            };
        }

        public List<Pet> GetAll()
        {
            return _ctx.Pets.Select(pet => new Pet()
            {
                Id = pet.Id,
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Color = pet.Color,
                Price = pet.Price,
                Type = pet.Type,
                PreviousOwner = pet.PreviousOwner,
                SoldDate = pet.SoldDate
            }).ToList();
        }

        public Pet GetById(int id)
        {
            return _ctx.Pets
                .Select(pet => new Pet()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Birthdate = pet.Birthdate,
                    Color = pet.Color,
                    Price = pet.Price,
                    Type = pet.Type,
                    PreviousOwner = pet.PreviousOwner,
                    SoldDate = pet.SoldDate
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public Pet Delete(int petId)
        {
            var savedEntity = _ctx.Pets.Remove(new Pet() { Id = petId }).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Birthdate = savedEntity.Birthdate,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                Type = savedEntity.Type,
                PreviousOwner = savedEntity.PreviousOwner,
                SoldDate = savedEntity.SoldDate
            };
        }
        

        public Pet Update(Pet pet)
        {
            var entity = new Pet()
            {
                Id = pet.Id,
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Color = pet.Color,
                Price = pet.Price,
                Type = pet.Type,
                PreviousOwner = pet.PreviousOwner,
                SoldDate = pet.SoldDate
            };
            var savedEntity = _ctx.Pets.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Birthdate = savedEntity.Birthdate,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                Type = savedEntity.Type,
                PreviousOwner = savedEntity.PreviousOwner,
                SoldDate = savedEntity.SoldDate
            };
        }
    }
}