using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;
using Truelsen.PetShopApplication.Infrastructure.EFSql.Entities;

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
            var entity = new Owner()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber
            };
            var savedEntity = _ctx.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                OwnerId = savedEntity.OwnerId,
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
                OwnerId = owner.OwnerId,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber
            }).ToList();
        }

        public Owner Delete(int ownerId)
        {
            var savedEntity = _ctx.Owners.Remove(new OwnerEntity() { OwnerId = ownerId }).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                OwnerId = savedEntity.OwnerId,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }

        public Owner Update(Owner owner)
        {
            var entity = new OwnerEntity()
            {
                OwnerId = (int) owner.OwnerId,
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
                OwnerId = savedEntity.OwnerId,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }
    }
}