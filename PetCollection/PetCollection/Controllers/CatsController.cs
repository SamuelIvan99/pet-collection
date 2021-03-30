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
    public class CatsController : ControllerBase
    {
        private ICatRepository _catRepository;

        public CatsController(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        // GET: api/<CatsController>
        [HttpGet]
        public async Task<IEnumerable<Cat>> Get()
        {
            return await _catRepository.GetAll();
        }

        // GET api/<CatsController>/5
        [HttpGet("id")]
        public async Task<Cat> Get([FromBody] Cat cat)
        {
            return await _catRepository.GetById(cat.Id);
        }

        // POST api/<CatsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Cat cat)
        {
            return await _catRepository.Insert(cat);
        }

        // PUT api/<CatsController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Cat cat)
        {
            Cat updatedCat = await _catRepository.GetById(cat.Id);
            updatedCat.CatchesMice = cat.CatchesMice;
            if (cat.Name != null)
                updatedCat.Name = cat.Name;
            if (cat.Breed != null)
                updatedCat.Breed = cat.Breed;
            if (cat.Birth != null)
                updatedCat.Birth = cat.Birth;
            if (cat.FeededNo > 0)
                updatedCat.FeededNo = cat.FeededNo;
            if (cat.AdultLength > 0)
                updatedCat.AdultLength = cat.AdultLength;

            return await _catRepository.Update(updatedCat);
        }

        // DELETE api/<CatsController>/5
        [HttpDelete]
        public async Task<bool> Delete([FromBody] Cat cat)
        {
            return await _catRepository.Delete(cat.Id);
        }
    }
}
