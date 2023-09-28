using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Books.Models;
using MVC_Books.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Web_Books.Services;

namespace Web_Books.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<Book> list = new List<Book>();

            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.AddBookAsync<ResponseDTO>(book);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(book);
        }
        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);
            if (response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(book);
                if(response !=null && response.IsSuccess)
                {
                    Console.WriteLine("Hej från updatebook");
                    return RedirectToAction(nameof(BookIndex));
                }                
            }
            return View(book);
        }
        public async Task<IActionResult>DeleteBook(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);
            if( response != null && response.IsSuccess)
            {
                Book model= JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult>DeleteBook(Book book)
        {
            var response = await _bookService.DeleteBookAsync<ResponseDTO>(book.Id);
            if(response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(BookIndex));
            }
            return NotFound();
        }
    }
}
