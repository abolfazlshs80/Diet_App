

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateDrugCommandValidator : AbstractValidator<UpdateDrugCommand>
{
    public UpdateDrugCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Please  Enter a Id ");
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a  name");
        RuleFor(x => x.Description).Length(2, 150).WithMessage("Please  Enter a  Description");


    }
}

