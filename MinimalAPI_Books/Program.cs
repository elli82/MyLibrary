using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Books.Interfaces;
using MinimalAPI_Books.Models;
using MinimalAPI_Books.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryBase, RepositoryBase>();

//DbConnection
builder.Services.AddDbContext<BookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BooksDbConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/books", async (IRepositoryBase bookRepo) =>
{
	try
	{
        var result = await bookRepo.GetAll();
        return Results.Ok(result);
    }
	catch (Exception)
	{
        return Results.StatusCode(500);
	}
});
app.MapGet("api/books/{id:int}", async (IRepositoryBase bookRepo, int id) =>
{
    var book = await bookRepo.GetById(id);
    if(book == null)
    {
        return Results.NotFound("The book was not found");
    }
    return Results.Ok(book);
});
app.MapPost("/api/books", async (IRepositoryBase bookRepo, Book book) =>
{
    var newBook = await bookRepo.Create(book);
    if(newBook == null)
    {
        return Results.BadRequest("Unable to add the new book");
    }
    return Results.Ok(newBook);
});
app.MapPut("/api/books", async (IRepositoryBase bookRepo, Book book, int id) =>
{
    var updatedBook = await bookRepo.Update(book,id);
    if(updatedBook != null) 
    {
        return Results.Ok($"Book with id {updatedBook.Id} was updated");
    }
    return Results.NotFound($"Unable to find book");
});
app.MapDelete("/api/books", async (IRepositoryBase bookRepo, int id) =>
{
    var bookToDelete = await bookRepo.Delete(id);
    if(bookToDelete != null)
    {
        return Results.Ok($"Book with id {bookToDelete.Id} is deleted");
    }
    return Results.NotFound("Unable to find the book");
});

app.Run();


