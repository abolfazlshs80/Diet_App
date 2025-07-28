

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateLifeCourseCommandValidator : AbstractValidator<CreateLifeCourseCommand>
{
    public CreateLifeCourseCommandValidator()
    {

        //RuleFor(x => x.ParentId)
        //    .NotNull().WithMessage("شناسه والد نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("نام الزامی است.")
            .Length(2, 150).WithMessage("نام باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

