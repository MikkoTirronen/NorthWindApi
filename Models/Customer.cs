namespace NorthWindApi.Models;

public class Customer : Person
{
    public string? CustomerId { get; set; }
    public string? ContactTitle { get; set; }
    public string? CompanyName { get; set; }

}