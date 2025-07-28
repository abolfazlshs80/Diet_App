

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateLifeCourseCommandValidator : AbstractValidator<UpdateLifeCourseCommand>
{
    public UpdateLifeCourseCommandValidator()
    {
        RuleFor(x => x.Id)
               .NotNull().WithMessage("شناسه نمی‌تواند تهی باشد.");

        //RuleFor(x => x.ParentId)
        //    .NotNull().WithMessage("شناسه والد نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("نام الزامی است.")
            .Length(2, 150).WithMessage("نام باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

