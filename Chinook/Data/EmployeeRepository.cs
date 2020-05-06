using Chinook.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class EmployeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<Employee> GetEmployee(string title)
        {
            var sql = @"select *
                        from Employee
                        where Title like '%sales%agent%'";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("title", title);

                var reader = cmd.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Title = (string)reader["Title"]
                    };

                    employees.Add(employee);
                }

                return employees;
            }
        }
    }
}
