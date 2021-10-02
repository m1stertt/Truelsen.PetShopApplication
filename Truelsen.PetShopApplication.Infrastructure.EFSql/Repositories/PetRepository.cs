using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var entity = new Pet()
            {
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Colors = pet.Colors,
                Price = pet.Price,
                Type = pet.Type,
                PreviousOwner = pet.PreviousOwner,
                SoldDate = pet.SoldDate
            };
            var savedEntity = _ctx.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                PetId = savedEntity.PetId,
                Name = savedEntity.Name,
                Birthdate = savedEntity.Birthdate,
                Colors = savedEntity.Colors,
                Price = savedEntity.Price,
                Type = savedEntity.Type,
                PreviousOwner = savedEntity.PreviousOwner,
                SoldDate = savedEntity.SoldDate
            };
        }

        public List<Pet> GetAll()
        {
            // return _ctx.Pets.Select(pet => new Pet()
            // {
            //     PetId = pet.PetId,
            //     PetTypeName = pet.PetTypeName,
            //     Birthdate = pet.Birthdate,
            //     Colors = new List<PetColor>(_ctx.PetColors.Select(entity => new PetColor()).Where(pce => pce.PetColorId == pet.PetId )),
            //     Price = pet.Price,
            //     // Type = new List<PetType>(_ctx.PetTypes.Select(entity => new PetType()).Where(pte => pte.pet == pet.PetId))
            //     // PreviousOwner = pet.PreviousOwner,
            //     SoldDate = pet.SoldDate
            // }).ToList();
            
            return _ctx.Pets
                .Include(pet => pet.PreviousOwner)
                .Include(pet => pet.Colors)
                .ToList();
        }

        public List<Pet> GetByType(string type)
        {
            return _ctx.Pets.Where(pet => pet.Type.PetTypeName.Equals(type)).Include(pet => pet.Type)
                .Include(pet => pet.PreviousOwner).ToList();
        }

        public Pet GetById(int id)
        {
            return _ctx.Pets
                .Select(pet => new Pet()
                {
                    PetId = pet.PetId,
                    Name = pet.Name,
                    Birthdate = pet.Birthdate,
                    Colors = pet.Colors,
                    Price = pet.Price,
                    Type = pet.Type,
                    PreviousOwner = pet.PreviousOwner,
                    SoldDate = pet.SoldDate
                })
                .FirstOrDefault(p => p.PetId == id);
        }

        public Pet Update(Pet pet)
        {
            var entity = new Pet()
            {
                PetId = pet.PetId,
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                Colors = pet.Colors,
                Price = pet.Price,
                Type = pet.Type,
                PreviousOwner = pet.PreviousOwner,
                SoldDate = pet.SoldDate
            };
            var savedEntity = _ctx.Pets.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                PetId = savedEntity.PetId,
                Name = savedEntity.Name,
                Birthdate = savedEntity.Birthdate,
                Colors = savedEntity.Colors,
                Price = savedEntity.Price,
                Type = savedEntity.Type,
                PreviousOwner = savedEntity.PreviousOwner,
                SoldDate = savedEntity.SoldDate
            };
        }

        public Pet Delete(int petId)
        {
            var savedEntity = _ctx.Pets.Remove(new Pet() {PetId = petId}).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                PetId = savedEntity.PetId,
                Name = savedEntity.Name,
                Birthdate = savedEntity.Birthdate,
                Colors = savedEntity.Colors,
                Price = savedEntity.Price,
                Type = savedEntity.Type,
                PreviousOwner = savedEntity.PreviousOwner,
                SoldDate = savedEntity.SoldDate
            };
        }
    }
}