using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.DurationAge.Commands.Delete;

public class DeleteDurationAgeCommandValidator : AbstractValidator<DeleteDurationAgeCommand>
{
    public DeleteDurationAgeCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

