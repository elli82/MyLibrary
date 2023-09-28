using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Books.Models;
using MVC_Books;
using static MVC_Books.StaticDetail;


namespace Web_Books.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> AddBookAsync<T>(Book book)
        {
            return await this.SendAsync<T>(new MVC_Books.Models.APIRequest()
            {
                APIType = StaticDetail.APIType.POST,
                Data = book,
                Url = StaticDetail.BookAPIBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new MVC_Books.Models.APIRequest
            {
                APIType = StaticDetail.APIType.DELETE,
                Url = StaticDetail.BookAPIBase + "/api/books/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await this.SendAsync<T>(new MVC_Books.Models.APIRequest()
            {
                APIType = StaticDetail.APIType.GET,
                Url = StaticDetail.BookAPIBase + "/api/books",
                AccessToken = ""
            });                 
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new MVC_Books.Models.APIRequest()
            {
                APIType = StaticDetail.APIType.GET,
                Url = StaticDetail.BookAPIBase + "/api/books/" + id,
                AccessToken = ""
            }); 
        }

        public async Task<T> UpdateBookAsync<T>(Book book)
        {
            return await this.SendAsync<T>(new MVC_Books.Models.APIRequest
            {
                APIType = StaticDetail.APIType.PUT,
                Data = book,
                Url = StaticDetail.BookAPIBase + "/api/books",
                AccessToken = ""
            });
        }
    }
}
