using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CQRS_MediatR.Domain.Entities;
public class PersonModel(Guid id,string name, int age, string taxId)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int Age { get; private set; } = age;
    public string TaxId { get; private set; } = taxId;

    public void Update(string name, int age, string taxId)
    {
        Name = name;
        Age = age;
        TaxId = taxId;
    }

}
