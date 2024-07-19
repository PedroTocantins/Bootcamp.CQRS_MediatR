using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using MediatR;

namespace Bootcamp.CQRS_MediatR.Application.Person.Commands;
public record DeletePersonCommand(Guid Id) : IRequest<bool>;


public sealed class DeletePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var deletedPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id)
           ?? throw new InvalidOperationException("Member not found");

        var wasPersonDeleted = _unitOfWork.PersonRepository.DeleteAsync(deletedPerson);
        await _unitOfWork.CommitAssync();

        return true;
    }
}
