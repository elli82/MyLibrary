using Microsoft.AspNetCore.Mvc;
using static MVC_Books.StaticDetail;

namespace MVC_Books.Models
{
    public class APIRequest
    {
        public APIType APIType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
