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
    public class DogsController : ControllerBase
    {
        private IDogRepository _dogRepository;

        public DogsController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        // GET: api/<DogsController>
        [HttpGet]
        public async Task<IEnumerable<Dog>> Get()
        {
            return await _dogRepository.GetAll();
        }

        // GET api/<DogsController>/5
        [HttpGet("id")]
        public async Task<Dog> Get([FromBody] Dog dog)
        {
            return await _dogRepository.GetById(dog.Id);
        }

        // POST api/<DogsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Dog dog)
        {
            return await _dogRepository.Insert(dog);
        }

        // PUT api/<DogsController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Dog dog)
        {
            Dog updatedDog = await _dogRepository.GetById(dog.Id);
            if (dog.Name != null)
                updatedDog.Name = dog.Name;
            if (dog.Breed != null)
                updatedDog.Breed = dog.Breed;
            if (dog.Birth != null)
                updatedDog.Birth = dog.Birth;
            if (dog.FeededNo > 0)
                updatedDog.FeededNo = dog.FeededNo;
            if (dog.TrainingDegree > 0 && dog.TrainingDegree < 11)
                updatedDog.TrainingDegree = dog.TrainingDegree;
            if (dog.AdultHeight > 0)
                updatedDog.AdultHeight = dog.AdultHeight;

            return await _dogRepository.Update(updatedDog);
        }

        // DELETE api/<DogsController>/5
        [HttpDelete]
        public async Task<bool> Delete([FromBody] Dog dog)
        {
            return await _dogRepository.Delete(dog.Id);
        }
    }
}
