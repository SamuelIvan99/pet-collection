using PetCollection.DataAccess.Interfaces;
using PetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCollection.DataAccess
{
    public class DogRepository : IDogRepository
    {
        public async Task<bool> Delete(string id)
        {
            string sql = "delete Pets where Id = @Id";

            return await DataAccess<Dog>.SaveData(sql, new { Id = id });
        }

        public async Task<IEnumerable<Dog>> GetAll()
        {
            string petType = "Dog";
            string sql = "select * from Pets where PetType = @PetType";

            return await DataAccess<Dog>.LoadData(sql, new { PetType = petType });
        }

        public async Task<Dog> GetById(string id)
        {
            string sql = "select * from Pets where Id = @Id";

            return (await DataAccess<Dog>.LoadData(sql, new { Id = id })).SingleOrDefault();
        }

        public async Task<bool> Insert(Dog data)
        {
            Dog dog = new Dog
            {
                Id = Guid.NewGuid().ToString(),
                Name = data.Name,
                Breed = data.Breed,
                Birth = data.Birth,
                FeededNo = data.FeededNo,
                TrainingDegree = data.TrainingDegree,
                AdultHeight = data.AdultHeight
            };
            string sql = "insert into Pets(Id, Name, Breed, Birth, FeededNo, TrainingDegree, AdultHeight, PetType) values (@Id, @Name, @Breed, @Birth, @FeededNo, @TrainingDegree, @AdultHeight, 'Dog')";

            return await DataAccess<Dog>.SaveData(sql, dog);
        }

        public async Task<bool> Update(Dog data)
        {
            string sql = "update Pets set Name = @Name, Breed = @Breed, FeededNo = @FeededNo, TrainingDegree = @TrainingDegree, AdultHeight = @AdultHeight where Id = @Id";

            return await DataAccess<Dog>.SaveData(sql, data);
        }
    }
}
