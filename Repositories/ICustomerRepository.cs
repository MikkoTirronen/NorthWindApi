namespace NorthWindApi.Repositories;

using NorthWindApi.Models;
public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(string id);
}