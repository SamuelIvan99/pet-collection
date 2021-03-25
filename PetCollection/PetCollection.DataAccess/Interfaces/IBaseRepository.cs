using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCollection.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Insert(T data);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(string id);

        Task<bool> Update(T data);

        Task<bool> Delete(string id);
    }
}
