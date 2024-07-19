using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CQRS_MediatR.Domain.Interfaces;
public interface IUnitOfWork
{
    IPersonRepository PersonRepository { get; }
    Task CommitAssync();
}
