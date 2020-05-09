using Chinook.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Chinook.Data
{
    public class EmployeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<Employee> GetEmployeeByTitle(string title)
        {
            var sql = @"select *
                        from Employee
                        where replace(Title, ' ', '')  = @title";

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, new { Title = title }).ToList();                
            }
        }
    }
}
