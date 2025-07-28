

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateDrugCommandValidator : AbstractValidator<UpdateDrugCommand>
{
    public UpdateDrugCommandValidator()
    {
        RuleFor(x => x.Id)
             .NotNull().WithMessage("شناسه دارو نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان دارو الزامی است.")
            .Length(2, 100).WithMessage("عنوان دارو باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("توضیحات دارو الزامی است.")
            .Length(2, 1000).WithMessage("توضیحات دارو باید بین ۲ تا ۱۵۰ کاراکتر باشد.");


    }
}

