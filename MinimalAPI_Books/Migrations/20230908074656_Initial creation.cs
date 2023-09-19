using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI_Books.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearofPublication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Available", "Genre", "Title", "YearofPublication" },
                values: new object[,]
                {
                    { 1, "J.R.R Tolkien", false, "Fantasy", "Sagan om Ringen", "1954" },
                    { 2, "Stephen King", true, "Skräck", "Pestens tid", "1978" },
                    { 3, "Jean M. Auel", true, "Historisk fiktion", "Hästarnas dal", "1982" },
                    { 4, "Jane Austen", true, "Romantik", "Stolthet och fördom", "1813" },
                    { 5, "Louisa May Alcott", false, "Coming of age", "Unga kvinnor", "1868" },
                    { 6, "J.K. Rowling", true, "Fantasy", "Harry Potter och de vises sten", "1997" },
                    { 7, "Douglas Adams", true, "Science ficion", "Liftarens guide till galaxen", "1979" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
