using Bootcamp.CQRS_MediatR.Domain.DTOs;
using Bootcamp.CQRS_MediatR.Domain.Entities;
using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using Bootcamp.CQRS_MediatR.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.CQRS_MediatR.Infrastructure.Repositories;
public class PersonRepository(ApplicationDataContext db) : IPersonRepository
{

    protected readonly ApplicationDataContext _db = db;

    public async Task<PersonDTO> AddAsync(PersonDTO person)
    {
        var personMap = new PersonModel(person.Id, person.Name, person.Age, person.TaxId);
        await _db.Person.AddAsync(personMap);
        return person;
    }

    public async Task<bool> DeleteAsync(PersonDTO person)
    {
        var existingPerson = await _db.Person.FindAsync(person.Id);
        if (existingPerson is null) throw new ArgumentNullException(nameof(person));
        _db.Person.Remove(existingPerson);
        return true;
    }

    public async Task<IEnumerable<PersonDTO>> GetAllAsync()
    {
        return _db.Person.Select(person => new PersonDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
            TaxId = person.TaxId,
        }).AsNoTracking();
    }

    public async Task<PersonDTO> GetByIdAsync(Guid id)
    {
        var person = await _db.Person.FindAsync(id);

        if (person is null)
            throw new ArgumentNullException(nameof(person));

        return new PersonDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
            TaxId = person.TaxId,
        };
    }

    public async void UpdateAsync(PersonDTO person)
    {
        var existingPerson = await _db.Person.FindAsync(person.Id);

        if (existingPerson is null) throw new ArgumentNullException(nameof(person));

        existingPerson.Update(person.Name, person.Age, person.TaxId);


        _db.Person.Update(existingPerson);

    }
}
