using Microsoft.AspNetCore.Mvc;

namespace Web_Books.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
