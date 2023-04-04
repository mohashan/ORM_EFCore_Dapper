using Microsoft.EntityFrameworkCore;
using ORM.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PublisherDbContext>(options =>
{
    options.UseSqlServer("Server=.;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True;");
});

var app = builder.Build();

app.MapGet("/Authors", async (PublisherDbContext db) => await db.Authors.ToListAsync());

app.MapGet("/Books", async (PublisherDbContext db) => await db.Books.ToListAsync());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
