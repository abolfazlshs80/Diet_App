

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateLifeCourseCommandValidator : AbstractValidator<CreateLifeCourseCommand>
{
    public CreateLifeCourseCommandValidator()
    {
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a  name");

    }
}

