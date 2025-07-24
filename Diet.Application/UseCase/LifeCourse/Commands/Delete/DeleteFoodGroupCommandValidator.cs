using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.LifeCourse.Commands.Delete;

public class DeleteLifeCourseCommandValidator : AbstractValidator<DeleteLifeCourseCommand>
{
    public DeleteLifeCourseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

