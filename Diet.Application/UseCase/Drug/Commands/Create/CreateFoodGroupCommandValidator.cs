

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
{
    public CreateDrugCommandValidator()
    {

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان دارو الزامی است.")
            .Length(2, 100).WithMessage("عنوان دارو باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("توضیحات دارو الزامی است.")
            .Length(2, 1000).WithMessage("توضیحات دارو باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

