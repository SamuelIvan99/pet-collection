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
    public class OwnersController : ControllerBase
    {
        private IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // GET: api/<OwnersController>
        [HttpGet]
        public async Task<IEnumerable<Owner>> Get()
        {
            return await _ownerRepository.GetAll();
        }

        // GET api/<OwnersController>/5
        [HttpGet("id")]
        public async Task<Owner> Get([FromBody] Owner owner)
        {
            return await _ownerRepository.GetById(owner.Id);
        }

        // POST api/<OwnersController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Owner owner)
        {
            return await _ownerRepository.Insert(owner);
        }

        // PUT api/<OwnersController>
        [HttpPut]
        public async Task<bool> Put([FromBody] Owner owner)
        {
            return await _ownerRepository.Update(owner);
        }

        // DELETE api/<OwnersController>/5
        [HttpDelete]
        public async Task<bool> Delete([FromBody] Owner owner)
        {
            return await _ownerRepository.Delete(owner.Id);
        }
    }
}
