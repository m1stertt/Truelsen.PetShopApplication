using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }


        public Owner Add(Owner owner)
        {
            var savedEntity = new Owner()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber
            };
            return new Owner()
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }

        public List<Owner> GetAll()
        {
            return _ctx.Owners.Select(owner => new Owner()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber
            }).ToList();
        }

        public Owner Delete(int ownerId)
        {
            var savedEntity = _ctx.Owners.Remove(new Owner() { Id = ownerId }).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }

        public Owner Update(Owner owner)
        {
            var entity = new Owner()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber
            };
            var savedEntity = _ctx.Owners.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = savedEntity.Id,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }
    }
}