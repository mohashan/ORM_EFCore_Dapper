using Microsoft.EntityFrameworkCore;
using ORM.EFCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PublisherDbContext>(options =>
{
    options.UseSqlServer("Server=.;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True;");
});

var app = builder.Build();

app.MapGet("/GetAuthors", async (PublisherDbContext db) =>
{
    return await db.Authors.ToListAsync();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();


//app.MapControllers();

app.Run();
