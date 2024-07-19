using Bootcamp.CQRS_MediatR.Domain.DTOs;
using Bootcamp.CQRS_MediatR.Domain.Entities;
using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using Bootcamp.CQRS_MediatR.Infrastructure.Repositories;
using MediatR;

namespace Bootcamp.CQRS_MediatR.Application.Person.Queries;
public record GetPersonByIdQuery(Guid Id) : IRequest<PersonDTO>;

public class GetPersonByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonByIdQuery, PersonDTO>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);
        return person;
    }
}
