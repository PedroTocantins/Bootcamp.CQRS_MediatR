using Bootcamp.CQRS_MediatR.Domain.DTOs;
using Bootcamp.CQRS_MediatR.Domain.Entities;
using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using MediatR;

namespace Bootcamp.CQRS_MediatR.Application.Person.Commands;
public record CreatePersonCommand(string Name, int Age, string TaxId) : IRequest<CreatePersonResult>;

public record CreatePersonResult(Guid Id);

public sealed class CreatePersonCommandHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<CreatePersonCommand, CreatePersonResult>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CreatePersonResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var newPerson = new PersonDTO { 
            Id = id,
            Name = request.Name,
            Age = request.Age,
            TaxId = request.TaxId,
        };

        var createdPerson = await _unitOfWork.PersonRepository.AddAsync(newPerson);
        await _unitOfWork.CommitAssync();

        return new CreatePersonResult(createdPerson.Id);
    }
}

