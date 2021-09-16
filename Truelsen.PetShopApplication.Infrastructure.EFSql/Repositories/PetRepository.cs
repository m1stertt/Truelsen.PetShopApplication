using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;
using Truelsen.PetShopApplication.Domain.IRepositories;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Repositories
{
    public class PetRepository : IOwnerRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Add(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Owner Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Owner Update(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}