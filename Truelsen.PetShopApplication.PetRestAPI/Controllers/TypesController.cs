using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Truelsen.PetShopApplication.Core.IServices;
using Truelsen.PetShopApplication.Core.Models;

namespace Truelsen.PetShopApplication.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesController : Controller
    {

        private readonly IPetTypeService _petTypeService;

        public TypesController(IPetTypeService petTypeTypeService)
        {
            _petTypeService = petTypeTypeService;
        }

        
        // Read all petsTypes.
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> ReadAll()
        {
            return Ok(_petTypeService.ReadAll());
        }
        
       
        // Find petTypes by id.
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Pet>> ReadById(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to find by id.");
            }
            return Ok(_petTypeService.FindById(id));
        }
        

        
        // Post new petType.
        [HttpPost]  
        public ActionResult<Pet> Post(PetType petType)
        {
            if (petType == null)
            {
                return BadRequest("A petType is required to create a pet in the repository");
            }

            return Ok(_petTypeService.Create(petType));
        }
        
        // Put petType
        [HttpPut("{id}")]  
        public ActionResult<Pet> Update(int id, PetType petType)
        {
            if (id < 1 || id != petType.PetTypeId)
            {
                return BadRequest("Correct id is needed to update a petType.");
            }

            
            return Ok(_petTypeService.Update(petType));
        }

        // Delete petType
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Correct id is needed to delete a petType.");
            }

            return Ok(_petTypeService.Delete(id));
        }

    }
        
    }
