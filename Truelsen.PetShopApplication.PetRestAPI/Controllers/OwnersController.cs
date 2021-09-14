using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OwnersController : ControllerBase
    {

        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        
        // Read all pets.
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> ReadAll()
        {
            return Ok(_ownerService.GetAll());
        }
        
        // // Find pet by type.
        // [HttpGet("{type}")]
        // public ActionResult<IEnumerable<Owner>> ReadByType(string type)
        // {
        //     if (string.IsNullOrEmpty(type))
        //     {
        //         return BadRequest("Name of the type is required to find by type.");
        //     }
        //     return Ok(_ownerService.FindByType(type));
        // }
        

        
        // Post new Pet.
        [HttpPost]  
        public ActionResult<Owner> Post(Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("A pet is required to create a owner in the repository");
            }

            return Ok(_ownerService.Create(owner));
        }
        
        // Put pet
        [HttpPut("{id}")]  
        public ActionResult<Owner> Update(int id, Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Correct id is needed to update a owner.");
            }

            
            return Ok(_ownerService.Update(owner));
        }

        // Delete pet
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Correct id is needed to update a owner.");
            }

            return Ok(_ownerService.Delete(id));
        }

    }
        
}
