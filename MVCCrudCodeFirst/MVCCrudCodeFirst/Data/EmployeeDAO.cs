using MVCCrudCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCrudCodeFirst.Data
{
    public class EmployeeDAO
    {
        private string connectionString = @"Data Source=.;Initial Catalog=CrudCodeFirst;Integrated Security=True";
        //we use simple query, on the top, we declare connectionString for this
        public List<Employee> FetchAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from dbo.Employees";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create new object, add it to the list to return 
                        Employee emp = new Employee();
                        emp.Id = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Email = reader.GetString(2);
                        emp.Mobile = reader.GetString(3);
                        emp.Age = reader.GetInt32(4);

                        employees.Add(emp);
                    }
                }
                connection.Close(); 
            }

            return employees;
        }
    }
}