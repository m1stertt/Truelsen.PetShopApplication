using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.DataAccess
{
    public class FakeDB
    {
        public static int PetId = 1;
        public static readonly List<Pet> Pets = new List<Pet>();

        public static int OwnerId = 1;
        public static readonly List<Owner> Owners = new List<Owner>();

    }
}