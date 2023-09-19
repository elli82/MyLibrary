using System.ComponentModel.DataAnnotations;

namespace MinimalAPI_Books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string YearofPublication { get; set; }

        public string Genre { get; set; }

        public bool Available { get; set; }
    }
}
