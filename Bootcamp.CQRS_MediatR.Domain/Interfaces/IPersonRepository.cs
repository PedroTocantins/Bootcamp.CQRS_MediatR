using Bootcamp.CQRS_MediatR.Domain.DTOs;
using Bootcamp.CQRS_MediatR.Domain.Entities;

namespace Bootcamp.CQRS_MediatR.Domain.Interfaces;
public interface IPersonRepository : IRepository<PersonDTO>
{
}
