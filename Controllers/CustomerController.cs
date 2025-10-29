using Microsoft.AspNetCore.Mvc;
using NorthWindApi.Repositories;

namespace NorthWindApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController(ICustomerRepository repository) : ControllerBase
{
    private readonly ICustomerRepository _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _repository.GetAllAsync();
        return Ok(customers);
    }
}