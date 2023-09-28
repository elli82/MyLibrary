using MinimalAPI_Books.Models;

namespace MinimalAPI_Books.Interfaces
{
    public interface IRepositoryBase
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book>Create(Book book);
        Task<Book> Update(Book book);
        Task<Book> Delete(int id);
    }
}
