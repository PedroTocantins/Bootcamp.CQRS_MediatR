using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using MediatR;

namespace Bootcamp.CQRS_MediatR.Application.Person.Commands;
public record UpdatePersonCommand(Guid Id, string Name, int Age, string TaxId) : IRequest<UpdatePersonResult>;

public record UpdatePersonResult(Guid Id);

public sealed class UpdatePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonCommand, UpdatePersonResult>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UpdatePersonResult> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var existingPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("Person not found");

        existingPerson.Name = request.Name;
        existingPerson.Age = request.Age;
        existingPerson.TaxId = request.TaxId;

        _unitOfWork.PersonRepository.UpdateAsync(existingPerson);

        await _unitOfWork.CommitAssync();

        return new UpdatePersonResult(request.Id);
    }
}