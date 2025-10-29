using NorthWindApi.Models;
using Microsoft.Data.SqlClient;
using System.Xml;
namespace NorthWindApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly string? _connectionString;

    public CustomerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("NorthWind");
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = new List<Customer>();
        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            using var cmd = new SqlCommand("Select * FROM Customers", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                customers.Add(new Customer
                {
                    CustomerId = reader.GetString(reader.GetOrdinal("CustomerId")),
                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                    ContactName = reader["ContactName"] as string,
                    ContactTitle = reader["ContactTitle"] as string,
                    Address = reader["Address"] as string,
                    City = reader["City"] as string,
                    Region = reader["Region"] as string,
                    PostalCode = reader["PostalCode"] as string,
                    Country = reader["Country"] as string,
                    Phone = reader["Phone"] as string,
                    Fax = reader["Fax"] as string,
                });
            }
        }
        return customers;
    }

    public async Task<Customer?> GetByIdAsync(string id)
    {
        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        using var cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Customer
            {
                CustomerId = reader.GetString(reader.GetOrdinal("CustomerID")),
                CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                ContactName = reader["ContactName"] as string,
                ContactTitle = reader["ContactTitle"] as string,
                Address = reader["Address"] as string,
                City = reader["City"] as string,
                Region = reader["Region"] as string,
                PostalCode = reader["PostalCode"] as string,
                Country = reader["Country"] as string,
                Phone = reader["Phone"] as string,
                Fax = reader["Fax"] as string
            };
        }

        return null;
    }
}