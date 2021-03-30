using PetCollection.DataAccess.Interfaces;
using PetCollection.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCollection.DataAccess
{
    public class OwnerPetRepository : IOwnerPetRepository
    {
        public async Task<bool> InsertOwnerPet(OwnerPet ownerPet)
        {
            string sql = "insert into OwnerPet(OwnerId, PetId, PetType) values (@OwnerId, @PetId, @PetType)";

            return await DataAccess<OwnerPet>.SaveData(sql, ownerPet);
        }

        public async Task<bool> DeleteOwnerPet(string ownerId, string petId)
        {
            string sql = "delete OwnerPet where OwnerId = @OwnerId and PetId = @PetId";

            return await DataAccess<string>.SaveData(sql, new { OwnerId = ownerId, PetId = petId });
        }

        public async Task<IEnumerable<OwnerPet>> GetOwnersPets(string ownerId)
        {
            string sql = "select * from OwnerPet where OwnerId = @OwnerId";

            return await DataAccess<OwnerPet>.LoadData(sql, new { OwnerId = ownerId });
        }

        public async Task<IEnumerable<OwnerPet>> GetPetsOwners(string petId)
        {
            string sql = "select * from OwnerPet where PetId = @PetId";

            return await DataAccess<OwnerPet>.LoadData(sql, new { PetId = petId });
        }
    }
}
