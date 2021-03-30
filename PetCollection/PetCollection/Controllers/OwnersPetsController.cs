using Microsoft.AspNetCore.Mvc;
using PetCollection.DataAccess.Interfaces;
using PetCollection.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersPetsController : ControllerBase
    {
        IOwnerPetRepository _ownerPetRepository;
        IDogRepository _dogRepository;
        ICatRepository _catRepository;
        IOwnerRepository _ownerRepository;

        public OwnersPetsController(IOwnerPetRepository ownerPetRepository, IDogRepository dogRepository, ICatRepository catRepository, IOwnerRepository ownerRepository)
        {
            _ownerPetRepository = ownerPetRepository;
            _dogRepository = dogRepository;
            _catRepository = catRepository;
            _ownerRepository = ownerRepository;
        }

        // GET: api/<OwnersPetsController>/ownersPets
        [HttpGet("ownersPets")]
        public async Task<IEnumerable<OwnerPet>> GetPetsOwners([FromBody] OwnerPet ownerPet)
        {
            return await _ownerPetRepository.GetOwnersPets(ownerPet.OwnerId);
        }

        // GET: api/<OwnersPetsController>/petsOwners
        [HttpGet("petsOwners")]
        public async Task<IEnumerable<OwnerPet>> GetOwnersPets([FromBody] OwnerPet ownerPet)
        {
            return await _ownerPetRepository.GetPetsOwners(ownerPet.PetId);
        }

        // POST api/<OwnersPetsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] OwnerPet data)
        {
            // check if owner's and pet's ids exists in db
            return await _ownerPetRepository.InsertOwnerPet(data);
        }


        // DELETE api/<ValuesController>
        [HttpDelete]
        public async Task<bool> Delete([FromBody] OwnerPet data)
        {
            return await _ownerPetRepository.DeleteOwnerPet(data.OwnerId, data.PetId);
        }
    }
}
