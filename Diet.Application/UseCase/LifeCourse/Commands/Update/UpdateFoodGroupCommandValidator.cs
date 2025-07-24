

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateLifeCourseCommandValidator : AbstractValidator<UpdateLifeCourseCommand>
{
    public UpdateLifeCourseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.ParentId).NotNull();
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a  name");

    }
}

