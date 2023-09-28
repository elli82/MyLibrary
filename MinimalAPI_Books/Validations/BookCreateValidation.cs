using FluentValidation;
using MinimalAPI_Books.DTOs;
using MinimalAPI_Books.Models;

namespace MinimalAPI_Books.Validations
{
    public class BookCreateValidation : AbstractValidator<Book>
    {
        public BookCreateValidation()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage("Book must have a title");
            RuleFor(model => model.Author).NotEmpty().WithMessage("Author must be registered");
            
        }
    }
}
