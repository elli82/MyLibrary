namespace MVC_Books
{
    public class StaticDetail
    {
        public static string BookAPIBase { get; set; }

        public enum APIType
        {
            GET, POST, PUT, DELETE
        }
    }
}
