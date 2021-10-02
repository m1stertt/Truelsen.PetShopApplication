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
                PetTypeName = petType.PetTypeName,
            };
            var savedEntity = _ctx.Add(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                PetTypeName = savedEntity.PetTypeName,
            };
        }

        public List<PetType> GetAll()
        {
            return _ctx.PetTypes.Select(petType => new PetType()
            {
                PetTypeId = petType.PetTypeId,
                PetTypeName = petType.PetTypeName,
            }).ToList();
        }

        public PetType Update(PetType petType)
        {
            var entity = new PetType()
            {
                PetTypeName = petType.PetTypeName,
            };
            var savedEntity = _ctx.PetTypes.Update(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                PetTypeId = petType.PetTypeId,
                PetTypeName = savedEntity.PetTypeName,
            };
        }

        public PetType Delete(int id)
        {
            var savedEntity = _ctx.PetTypes.Remove(new PetType() {PetTypeId = id}).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                PetTypeId = id,
                PetTypeName = savedEntity.PetTypeName,
            };
        }

        public PetType GetById(int id)
        {
            return _ctx.Pets
                .Select(petType => new PetType()
                {
                    PetTypeName = petType.Name,
                })
                .FirstOrDefault(p => p.PetTypeId == id);
        }
    }
}