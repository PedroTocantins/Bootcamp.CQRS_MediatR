namespace Bootcamp.CQRS_MediatR.API.Results;

public class PersonsResult
{
    public Guid Id { get;  set; } 
    public string Name { get;  set; }
    public int Age { get;  set; }
    public string TaxId { get;  set; } 
}
