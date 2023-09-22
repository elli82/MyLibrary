namespace MinimalAPI_Books.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string YearofPublication { get; set; }

        public string Genre { get; set; }

        public bool Available { get; set; }
    }
}
