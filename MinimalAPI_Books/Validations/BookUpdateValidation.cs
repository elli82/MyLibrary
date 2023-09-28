using FluentValidation;
using MinimalAPI_Books.Models;
using MinimalAPI_Books.DTOs;

namespace MinimalAPI_Books.Validations
{
    public class BookUpdateValidation: AbstractValidator<Book>
    {
        public BookUpdateValidation()
        {
            RuleFor(model => model.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(model => model.Title).NotEmpty().WithMessage("Book must have a title");
            RuleFor(model => model.Author).NotEmpty().WithMessage("Author must be registered");
        }
    }
}
