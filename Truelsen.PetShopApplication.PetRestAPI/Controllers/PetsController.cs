using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        
        // Read all pets.
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> ReadAll()
        {
            return Ok(_petService.GetAll());
        }
        
        
        // Find pet by type.
        [HttpGet("{type}")]
        public ActionResult<IEnumerable<Pet>> ReadByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("PetTypeName of the type is required to find by type.");
            }
            return Ok(_petService.FindByType(type));
        }
        
        // Find pet by id.
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Pet>> ReadByType(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to find by id.");
            }
            return Ok(_petService.FindById(id));
        }
        

        
        // Post new Pet.
        [HttpPost]  
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("A pet is required to create a pet in the repository");
            }

            return Ok(_petService.Create(pet));
        }
        
        // Put pet
        [HttpPut("{id}")]  
        public ActionResult<Pet> Update(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.PetId)
            {
                return BadRequest("Correct id is needed to update a pet.");
            }

            
            return Ok(_petService.Update(pet));
        }

        // Delete pet
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Correct id is needed to delete a pet.");
            }

            return Ok(_petService.Delete(id));
        }

    }
        
    }
