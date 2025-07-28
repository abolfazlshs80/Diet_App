

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateDiseaseCommandValidator : AbstractValidator<UpdateDiseaseCommand>
{
    public UpdateDiseaseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه بیماری نمی‌تواند تهی باشد.");

        //RuleFor(x => x.ParentId)
        //    .NotNull().WithMessage("شناسه والد نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان بیماری الزامی است.")
            .Length(2, 150).WithMessage("عنوان بیماری باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

