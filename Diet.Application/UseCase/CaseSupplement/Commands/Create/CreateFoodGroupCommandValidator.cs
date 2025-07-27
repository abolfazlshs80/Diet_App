

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseSupplementCommandValidator : AbstractValidator<CreateCaseSupplementCommand>
{
    public CreateCaseSupplementCommandValidator()
    {

        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.SupplementId).NotNull().NotEmpty();

    }
}

