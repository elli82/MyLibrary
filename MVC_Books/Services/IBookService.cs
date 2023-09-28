using MinimalAPI_Books.Models;

namespace Web_Books.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> AddBookAsync<T>(Book book);
        Task<T> UpdateBookAsync<T>(Book book);
        Task<T> DeleteBookAsync<T>(int id);
    }
}
