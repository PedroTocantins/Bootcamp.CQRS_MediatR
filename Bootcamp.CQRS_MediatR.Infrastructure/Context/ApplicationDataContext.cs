using Bootcamp.CQRS_MediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.CQRS_MediatR.Infrastructure.Context;
public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    public DbSet<PersonModel> Person { get; set; }

}
