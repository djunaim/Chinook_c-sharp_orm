using Chinook.Model;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;

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

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Customer>(sql, new { Country = country}).AsList();
            }
        }

        public List<InvoiceWithCustomerData> GetCustomerInvoiceByCountry(string country)
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

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<InvoiceWithCustomerData>(sql, new { Country = country }).AsList();
            }
        }

        internal List<Customer> GetAllNonUsaCustomers(string country)
        {
            var sql = @"select Customer.FirstName, Customer.LastName, Customer.Country
                        from Customer
                        where Customer.Country != @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Customer>(sql, new { Country = country }).AsList();
            }
        }
    }
}