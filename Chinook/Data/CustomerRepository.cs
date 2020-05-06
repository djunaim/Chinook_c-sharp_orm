using Chinook.Model;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Chinook.Data
{
    public class CustomerRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<Customer> GetByCountry(string country)
        {

            var sql = @"select FirstName, LastName
                        from Customer
                        where Customer.Country = @Country";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();

                var customers = new List<Customer>();

                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                    };

                    customers.Add(customer);
                }
                return customers;
            }
        }

        public List<Customer> GetInvoiceByCountry(string country)
        {
            var sql = @"select Customer.FirstName, 
                        Customer.LastName, 
	                    Invoice.InvoiceId, 
	                    Invoice.InvoiceDate, 
	                    Customer.Country
                        from Customer
	                        join Invoice
		                        on Customer.CustomerId = Invoice.CustomerId
                        where Customer.Country = @Country";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();

                var customers = new List<Customer>();

                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                    };

                    customers.Add(customer);
                }
                return customers;
            }
        }
    }
}