using System;
using System.Collections.Generic;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.Infrastructure.EFSql.Entities
{
    public class PetEntity
    {
        public int PetId { get; set; }
        public int PetTypeId { get; set; }
        

        
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
        

    }
}