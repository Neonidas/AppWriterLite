using System;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace CSRocks
{
    public class DataBaseHandler
    {
        public static async Task<List<string>> GetWordsLike(string word)
        {
            string connectionString = "Data Source=Dictionary.db";
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                var query = await connection.QueryAsync<string>(
                    "select Value from Words where Value like @Predict",
                    new { Predict = word + "%" });

                return query.ToList();
            }
        }
    }
}
