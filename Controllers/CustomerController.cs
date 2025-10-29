using Microsoft.AspNetCore.Mvc;
using NorthWindApi.Repositories;
using NorthWindApi.Services;

namespace NorthWindApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController(CustomerService service) : ControllerBase
{
    private readonly CustomerService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();

        return Ok(customer);

    }
}