

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand>
{
    public CreateDiseaseCommandValidator()
    {

        //RuleFor(x => x.ParentId)
        //    .NotNull().WithMessage("شناسه والد نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان بیماری الزامی است.")
            .Length(2, 150).WithMessage("عنوان بیماری باید بین ۲ تا ۱۵۰ کاراکتر باشد.");
    }
}

