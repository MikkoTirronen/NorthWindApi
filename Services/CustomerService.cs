using NorthWindApi.Repositories;
using NorthWindApi.Dtos;
namespace NorthWindApi.Services;

public class CustomerService(ICustomerRepository repository): ICustomerService
{
    private readonly ICustomerRepository _repository = repository;

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(c => new CustomerDto
        {
            CustomerId = c.CustomerId,
            CompanyName = c.CompanyName,
            ContactName = c.ContactName,
            Country = c.Country
        });
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(string id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null) return null;

        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            CompanyName = customer.CompanyName,
            ContactName = customer.ContactName,
            Country = customer.Country
        };
    }
}