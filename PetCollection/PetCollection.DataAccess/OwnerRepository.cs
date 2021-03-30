using PetCollection.DataAccess.Interfaces;
using PetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCollection.DataAccess
{
    public class OwnerRepository : IOwnerRepository
    {
        public async Task<bool> Insert(Owner data)
        {
            Owner owner = new Owner
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
            };
            string sql = "insert into Owners(Id, FirstName, LastName, Email) values (@Id, @FirstName, @LastName, @Email)";

            return await DataAccess<Owner>.SaveData(sql, owner);
        }

        public async Task<IEnumerable<Owner>> GetAll()
        {
            string sql = "select * from Owners";
            return await DataAccess<Owner>.LoadData(sql);
        }

        public async Task<Owner> GetById(string id)
        {
            string sql = "select * from Owners where Id = @Id";
            return (await DataAccess<Owner>.LoadData(sql, new { Id = id })).SingleOrDefault();
        }

        public async Task<bool> Update(Owner data)
        {
            string sql = "update Owners set FirstName = @FirstName, LastName = @LastName, Email = @Email where Id = @Id";
            return await DataAccess<Owner>.SaveData(sql, data);
        }

        public async Task<bool> Delete(string id)
        {
            string sql = "delete Owners where Id = @Id";

            return await DataAccess<string>.SaveData(sql, new { Id = id });
        }
    }
}
