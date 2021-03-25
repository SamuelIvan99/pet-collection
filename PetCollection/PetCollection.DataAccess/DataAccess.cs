using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PetCollection.DataAccess
{
    public static class DataAccess<T>
    {
        private const string ConnectionString = "Server=LAPTOP-SICODER;Database=PetsDb;Integrated Security=true;";

        public async static Task<IEnumerable<T>> LoadData(string sql)
        {
            using IDbConnection conn = new SqlConnection(ConnectionString);
            var result = await conn.QueryAsync<T>(sql);
            return result;
        }

        public async static Task<T> LoadData<S>(string sql, S id)
        {
            using IDbConnection conn = new SqlConnection(ConnectionString);
            var result = (await conn.QueryAsync<T>(sql, id)).SingleOrDefault();
            return result;
        }

        public async static Task<bool> SaveData(string sql, T data)
        {
            using IDbConnection conn = new SqlConnection(ConnectionString);
            var result = await conn.ExecuteAsync(sql, data);
            return result > 0;
        }
    }
}
