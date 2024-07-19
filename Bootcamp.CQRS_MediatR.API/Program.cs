using Bootcamp.CQRS_MediatR.Domain.Interfaces;
using Bootcamp.CQRS_MediatR.Infrastructure;
using Bootcamp.CQRS_MediatR.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureConnection(builder.Configuration);

//Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var myhandlers = AppDomain.CurrentDomain.Load("Bootcamp.CQRS_MediatR.Application");
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(myhandlers);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
