using Bootcamp.CQRS_MediatR.Domain.DTOs;
using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using Bootcamp.CQRS_MediatR.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CQRS_MediatR.Application.Person.Queries;

public record GetAllPersonQuery() : IRequest<IEnumerable<PersonDTO>>;

public class GetAllPersonQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<PersonDTO>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
    {
        var people = await _unitOfWork.PersonRepository.GetAllAsync();
        return people;
    }
}