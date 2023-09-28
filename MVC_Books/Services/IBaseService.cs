using MVC_Books.Models;

namespace Web_Books.Services
{
    public interface IBaseService : IDisposable 
    {
        ResponseDTO responseModel { get; set; }

        Task<T>SendAsync<T>( APIRequest apiRequest);
    }
}
