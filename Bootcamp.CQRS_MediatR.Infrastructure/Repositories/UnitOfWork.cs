using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using Bootcamp.CQRS_MediatR.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CQRS_MediatR.Infrastructure.Repositories;
public class UnitOfWork(ApplicationDataContext db) : IUnitOfWork, IDisposable
{
    protected readonly ApplicationDataContext _db = db;

    private IPersonRepository? _personRepository;

   
    public IPersonRepository PersonRepository
    {
        get
        {
            return _personRepository = _personRepository ?? new PersonRepository(_db);
        }
    }


    public async Task CommitAssync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
