using Dapper;
using ORM.Model;
using System.Data;
using System.Data.SqlClient;
using System.Net;

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

app.MapGet("/Books/{bookId:int?}", (int? bookId) =>
{
    return bookId.HasValue
        ? Results.Ok(connection.QueryAsync<Book>($"select * from Books where id = {bookId}").Result.FirstOrDefault())
        : Results.Ok(connection.QueryAsync<Book>("select * from Books").Result.ToList());
});

app.MapGet("/Authors/{authorId:int?}", (int? authorId) =>
{
    return authorId.HasValue
            ? Results.Ok(connection.QueryAsync<Author>($"select * from Authors where id = {authorId}").Result.FirstOrDefault())
            : Results.Ok(connection.QueryAsync<Author>("select * from Authors").Result.ToList());
});
app.UseHttpsRedirection();

app.Run();
