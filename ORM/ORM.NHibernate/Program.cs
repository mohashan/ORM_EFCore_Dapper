using Microsoft.AspNetCore.Http.HttpResults;
using NHibernate;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Authors", async (ISessionFactory _sessionFactory) =>
{
    _sessionFactory = NHibernateSessionFactory.SessionFactory;
    using (var session = _sessionFactory.OpenSession())
    {
        var authors = session.Query<ORM.Model.Author>().ToList();
        return Results.Ok(authors);
    }
});


app.Run();
