using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Books.DTOs;
using MinimalAPI_Books.Interfaces;
using MinimalAPI_Books.Models;
using MinimalAPI_Books.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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

// CRUD

app.MapGet("/api/books", async (IRepositoryBase bookRepo) =>
{
    // before creating the MVCapp, simpler API
	//try        
	//{
 //       var result = await bookRepo.GetAll();
 //       return Results.Ok(result);
 //   }
	//catch (Exception)
	//{
 //       return Results.StatusCode(500);
	//}

    APIResponse response = new APIResponse();

    response.Result= await bookRepo.GetAll();
    response.IsSuccess= true;
    response.StatusCode=System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetAllBooks").Produces(200);


app.MapGet("api/books/{id:int}", async (IRepositoryBase bookRepo, int id) =>
{
    //var book = await bookRepo.GetById(id);
    //if(book == null)
    //{
    //    return Results.NotFound("The book was not found");
    //}
    //return Results.Ok(book);

    APIResponse response = new APIResponse();
    
    var book= await bookRepo.GetById(id);

    if (book != null)
    {
        response.Result= book;
        response.IsSuccess= true;
        response.StatusCode= System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }
    return Results.NotFound($"Book with id: {id} was not found");

}).WithName("GetBook");


app.MapPost("/api/books", async (IRepositoryBase bookRepo, Book book /*IValidator<Book> validator*/) =>
{
    APIResponse response = new () { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    //var validResult = await validator.ValidateAsync(book);  // does this work? unsure
    //if (!validResult.IsValid)
    //{
    //    return Results.BadRequest(response);
    //}

    var newBook = await bookRepo.Create(book);
    if(newBook == null)
    {
        return Results.BadRequest("Unable to add the new book");
    }

    response.Result= newBook;
    response.IsSuccess= true;
    response.StatusCode = System.Net.HttpStatusCode.Created;

    return Results.Ok(response);

}).WithName("AddBook").Accepts<Book>("application/json").Produces<APIResponse>(201).Produces(400);


app.MapPut("/api/books/", async (IRepositoryBase bookRepo, Book book /*IValidator<Book>validator*/) =>
{
    APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    //var validResult = await validator.ValidateAsync(book);
    //if (!validResult.IsValid)
    //{
    //    response.ErrorMessages.Add(validResult.Errors.FirstOrDefault().ToString());
    //}

    var updatedBook = await bookRepo.Update(book);
    if(updatedBook != null) 
    {
        response.Result= updatedBook;
        response.IsSuccess= true;
        response.StatusCode= System.Net.HttpStatusCode.OK;

        return Results.Ok(response);
    }
    return Results.NotFound("Book was NOT updated");

}).WithName("UpdateBook").Accepts<Book>("application/json").Produces<APIResponse>(200).Produces(400);


app.MapDelete("/api/books/{id:int}", async (IRepositoryBase bookRepo, int id) =>
{
    APIResponse response = new APIResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

    var bookToDelete = await bookRepo.Delete(id);
    if(bookToDelete != null)
    {
        response.Result= bookToDelete;
        response.IsSuccess= true;
        response.StatusCode = System.Net.HttpStatusCode.NoContent;
        return Results.Ok(response);
    }
    return Results.NotFound("Unable to find the book");
}).WithName("DeleteBook").Produces<APIResponse>(200).Produces(400);

app.Run();


