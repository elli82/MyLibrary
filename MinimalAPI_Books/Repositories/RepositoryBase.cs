using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Books.Interfaces;
using MinimalAPI_Books.Models;

namespace MinimalAPI_Books.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly BookDbContext _db;

        public RepositoryBase(BookDbContext db)
        {
            _db = db;
        }

        public async Task<Book> Create(Book book)
        {
             await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Delete(int id)
        {
            var bookToDelete= await _db.Books.FirstOrDefaultAsync(b => b.Id==id);
           if (bookToDelete==null)
            {
                return null;
            }
                _db.Books.Remove(bookToDelete);
                await _db.SaveChangesAsync();
                return bookToDelete;           
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var allBooks = await _db.Books.ToListAsync();
            return allBooks;
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
                return book;
        }
        public async Task<Book> Update(Book book, int id)
        {
            var updatedBook= await _db.Books.FirstOrDefaultAsync(b => b.Id==id);
            if (updatedBook != null)
            {
                updatedBook.Id = id;
                updatedBook.Title = book.Title;
                updatedBook.Author = book.Author;
                updatedBook.Genre = book.Genre;
                updatedBook.YearofPublication = book.YearofPublication;
                updatedBook.Available = book.Available;

                await _db.SaveChangesAsync();
                return updatedBook;
            }
            return null;
        }         
    }
}
