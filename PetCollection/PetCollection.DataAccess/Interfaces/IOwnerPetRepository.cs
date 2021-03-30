using PetCollection.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCollection.DataAccess.Interfaces
{
    public interface IOwnerPetRepository
    {
        Task<bool> InsertOwnerPet(OwnerPet ownerPet);

        Task<bool> DeleteOwnerPet(string ownerId, string petId);

        Task<IEnumerable<OwnerPet>> GetOwnersPets(string ownerId);

        Task<IEnumerable<OwnerPet>> GetPetsOwners(string petId);
    }
}
