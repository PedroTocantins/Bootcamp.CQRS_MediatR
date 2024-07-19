using Bootcamp.CQRS_MediatR.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CQRS_MediatR.Infrastructure;
public static class DbConnection
{
    public static IServiceCollection ConfigureConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerConnection = configuration.GetConnectionString("PeopleDatabase");

        services.AddDbContext<ApplicationDataContext>(options =>
                options.UseSqlServer(sqlServerConnection));


        return services;
    }
}
