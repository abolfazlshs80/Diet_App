

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseDrugCommandValidator : AbstractValidator<CreateCaseDrugCommand>
{
    public CreateCaseDrugCommandValidator()
    {

        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.DrugId).NotNull().NotEmpty();

    }
}

