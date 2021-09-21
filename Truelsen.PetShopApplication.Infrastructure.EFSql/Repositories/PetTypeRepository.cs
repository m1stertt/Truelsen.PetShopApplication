using System.Collections.Generic;
using System.Linq;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetTypeRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public PetType Add(PetType petType)
        {
            var entity = new PetType()
            {
                Name = petType.Name,
            };
            var savedEntity = _ctx.Add(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                Name = savedEntity.Name,
            };
        }

        public List<PetType> GetAll()
        {
            return _ctx.PetTypes.Select(petType => new PetType()
            {
                PetTypeId = petType.PetTypeId,
                Name = petType.Name,
            }).ToList();
        }

        public PetType Update(PetType petType)
        {
            var entity = new PetType()
            {
                Name = petType.Name,
            };
            var savedEntity = _ctx.PetTypes.Update(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                PetTypeId = petType.PetTypeId,
                Name = savedEntity.Name,
            };
        }

        public PetType Delete(int id)
        {
            var savedEntity = _ctx.PetTypes.Remove(new PetType() {PetTypeId = id}).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                PetTypeId = id,
                Name = savedEntity.Name,
            };
        }

        public PetType GetById(int id)
        {
            return _ctx.Pets
                .Select(petType => new PetType()
                {
                    Name = petType.Name,
                })
                .FirstOrDefault(p => p.PetTypeId == id);
        }
    }
}