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

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    // Commit Migration to have db on local sql server, plus some sample data
    var dataContext = scope.ServiceProvider.GetRequiredService<PublisherDbContext>();
    dataContext.Database.Migrate();
}

app.MapGet("/Authors/{authorId:int?}", async (PublisherDbContext db, int? authorId) =>
{
    return authorId.HasValue
    ? Results.Ok(await db.Authors.FirstOrDefaultAsync(c => c.Id == authorId))
    : Results.Ok(await db.Authors.ToListAsync());
});

app.MapGet("/Books/{bookId:int?}", async (PublisherDbContext db, int? bookId) =>
{
    return bookId.HasValue
    ? Results.Ok(await db.Books.FirstOrDefaultAsync(c => c.Id == bookId))
    : Results.Ok(await db.Books.ToListAsync());
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
