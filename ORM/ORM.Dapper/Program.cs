using Dapper;
using ORM.Model;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

IDbConnection connection = new SqlConnection("Server=.;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True;");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/Books", () => connection.QueryAsync<Book>("select * from Books").Result.ToList());

app.MapGet("/Authors", () => connection.QueryAsync<Book>("select * from Authors").Result.ToList());

app.UseHttpsRedirection();

app.Run();
