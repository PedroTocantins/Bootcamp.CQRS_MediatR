using Bootcamp.CQRS_MediatR.API.Requests;
using Bootcamp.CQRS_MediatR.Application.Person.Commands;
using Bootcamp.CQRS_MediatR.Application.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.CQRS_MediatR.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllPerson()
    {
        var query = new GetAllPersonQuery();
        var people = await _mediator.Send(query);
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(Guid id)
    {
        var query = new GetPersonByIdQuery(id);
        var person = await _mediator.Send(query);
        return person != null ? Ok(person) : NotFound("Member not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson([FromBody] CreateAndUpdateProductRequest request)
    {
        var command = new CreatePersonCommand(request.Name,request.Age, request.TaxId);
        
        var createdPerson = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] CreateAndUpdateProductRequest request)
    {
        var command = new UpdatePersonCommand(id, request.Name, request.Age, request.TaxId);

        var updatePerson = await _mediator.Send(command);
        return updatePerson != null ? Ok(updatePerson) : NotFound("Member not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var command = new DeletePersonCommand(id);
        var deletePerson = await _mediator.Send(command);

        return Ok(true);
    }
}
