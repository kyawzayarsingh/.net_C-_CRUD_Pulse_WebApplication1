using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVCCrudCodeFirst.Models
{
    public class DapperORM
    {
        public static string connectionString = @"Data Source=.; Initial Catalog=CrudCodeFirst;Integrated Security=True";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(procedureName, param,commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteWithoutScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return (T) Convert.ChangeType(conn.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof (T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}