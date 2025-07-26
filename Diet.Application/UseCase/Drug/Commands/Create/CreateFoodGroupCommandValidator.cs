

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
{
    public CreateDrugCommandValidator()
    {
        RuleFor(x => x.Title).Length(2, 100).WithMessage("Please  Enter a  name");
        RuleFor(x => x.Description).Length(2, 1000).WithMessage("Please  Enter a  Description");

    }
}

