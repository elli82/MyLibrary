using Microsoft.EntityFrameworkCore;

namespace MinimalAPI_Books.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base (options)
        {
            
        }
        //skapa tabellen
        public DbSet<Book> Books { get; set; }

        //skicka med data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().
                HasData(new Book
                {
                    Id = 1,
                    Title = "Sagan om Ringen",
                    Author = "J.R.R Tolkien",
                    Genre = "Fantasy",
                    YearofPublication = "1954",
                    Available = false
                });
            modelBuilder.Entity<Book>().
               HasData(new Book
               {
                   Id = 2,
                   Title = "Pestens tid",
                   Author = "Stephen King",
                   Genre = "Skräck",
                   YearofPublication = "1978",
                   Available = true
               });
            modelBuilder.Entity<Book>().
               HasData(new Book
               {
                   Id = 3,
                   Title = "Hästarnas dal",
                   Author = "Jean M. Auel",
                   Genre = "Historisk fiktion",
                   YearofPublication = "1982",
                   Available = true
               });
            modelBuilder.Entity<Book>().
               HasData(new Book
               {
                   Id = 4,
                   Title = "Stolthet och fördom",
                   Author = "Jane Austen",
                   Genre = "Romantik",
                   YearofPublication = "1813",
                   Available = true
               }); 
            modelBuilder.Entity<Book>().
                HasData(new Book
                {
                    Id = 5,
                    Title = "Unga kvinnor",
                    Author = "Louisa May Alcott",
                    Genre = "Coming of age",
                    YearofPublication = "1868",
                    Available = false
                }); 
            modelBuilder.Entity<Book>().
                HasData(new Book
                {
                    Id = 6,
                    Title = "Harry Potter och de vises sten",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    YearofPublication = "1997",
                    Available = true
                }); 
            modelBuilder.Entity<Book>().
                HasData(new Book
                {
                    Id = 7,
                    Title = "Liftarens guide till galaxen",
                    Author = "Douglas Adams",
                    Genre = "Science ficion",
                    YearofPublication = "1979",
                    Available = true
                });

        }

    }
}
