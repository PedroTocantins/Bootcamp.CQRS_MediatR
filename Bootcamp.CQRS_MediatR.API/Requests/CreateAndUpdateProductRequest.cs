namespace Bootcamp.CQRS_MediatR.API.Requests;

public class CreateAndUpdateProductRequest
{
    public string Name { get; set; } 
    public int Age { get; set; } 
    public string TaxId { get; set; } 
}
