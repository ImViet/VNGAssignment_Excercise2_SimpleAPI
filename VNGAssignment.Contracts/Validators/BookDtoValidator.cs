using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNGAssignment.Contracts.Dtos.BookDto;

namespace VNGAssignment.Contracts.Validators
{
    public class BookDtoValidator: AbstractValidator<BookDto>
    {
        public BookDtoValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("BookId is empty");
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Title is incorrect");
            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Author is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Author is incorrect");
            RuleFor(x => x.PublishedYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Published year is empty")
                .GreaterThan(0)
                .WithMessage("Published year is incorrect");
        }
    }
    public class BookCreateDtoValidator: AbstractValidator<BookCreateDto>
    {
        public BookCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Title is incorrect");
            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Author is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Author is incorrect");
            RuleFor(x => x.PublishedYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Published year is empty")
                .GreaterThan(0)
                .WithMessage("Published year is incorrect");
        }
    }
    public class BookUpdateDtoValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Title is incorrect");
            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("Author is empty")
                .Must(CommonValidator.ContainLetters)
                .WithMessage("Author is incorrect");
            RuleFor(x => x.PublishedYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Published year is empty")
                .GreaterThan(0)
                .WithMessage("Published year is incorrect");
        }
    }
}
