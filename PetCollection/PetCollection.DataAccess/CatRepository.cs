using PetCollection.DataAccess.Interfaces;
using PetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCollection.DataAccess
{
    public class CatRepository : ICatRepository
    {
        public async Task<bool> Delete(string id)
        {
            string sql = "delete Pets where Id = @Id";

            return await DataAccess<Cat>.SaveData(sql, new { Id = id });
        }

        public async Task<IEnumerable<Cat>> GetAll()
        {
            string petType = "Cat";
            string sql = "select * from Pets where PetType = @PetType";

            return await DataAccess<Cat>.LoadData(sql, new { PetType = petType });
        }

        public async Task<Cat> GetById(string id)
        {
            string sql = "select * from Pets where Id = @Id";

            return (await DataAccess<Cat>.LoadData(sql, new { Id = id })).SingleOrDefault();
        }

        public async Task<bool> Insert(Cat data)
        {
            Cat cat = new Cat
            {
                Id = Guid.NewGuid().ToString(),
                Name = data.Name,
                Breed = data.Breed,
                Birth = data.Birth,
                FeededNo = data.FeededNo,
                AdultLength = data.AdultLength,
                CatchesMice = data.CatchesMice
            };
            string sql = "insert into Pets(Id, Name, Breed, Birth, FeededNo, AdultLength, CatchesMice, PetType) values (@Id, @Name, @Breed, @Birth, @FeededNo, @AdultLength, @CatchesMice, 'Cat')";

            return await DataAccess<Cat>.SaveData(sql, cat);
        }

        public async Task<bool> Update(Cat data)
        {
            string sql = "update Pets set Name = @Name, Breed = @Breed, FeededNo = @FeededNo, AdultLength = @AdultLength, CatchesMice = @CatchesMice where Id = @Id";

            return await DataAccess<Cat>.SaveData(sql, data);
        }
    }
}
