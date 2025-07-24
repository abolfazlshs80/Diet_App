

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateDurationAgeCommandValidator : AbstractValidator<UpdateDurationAgeCommand>
{
    public UpdateDurationAgeCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a  name");

    }
}

