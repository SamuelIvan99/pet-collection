using Dapper;
using System;
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
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = await conn.QueryAsync<T>(sql);
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public async static Task<T> LoadData<S>(string sql, S id)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var result = (await conn.QueryAsync<T>(sql, id)).SingleOrDefault(); ;
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async static Task<bool> SaveData<S>(string sql, S data)
        {
            using (IDbConnection conn = new SqlConnection(ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var transaction = conn.BeginTransaction();
                try
                {
                    var result = await conn.ExecuteAsync(sql, data, transaction);
                    transaction.Commit();
                    return result > 0;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
}
