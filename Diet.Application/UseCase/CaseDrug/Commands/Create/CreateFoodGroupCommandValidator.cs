

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseDrugCommandValidator : AbstractValidator<CreateCaseDrugCommand>
{
    public CreateCaseDrugCommandValidator()
    {
        RuleFor(x => x.CaseId)
                  .NotNull().WithMessage("شناسه پرونده نمی‌تواند null باشد.")
                  .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.DrugId)
            .NotNull().WithMessage("شناسه دارو نمی‌تواند null باشد.")
            .NotEmpty().WithMessage("شناسه دارو نمی‌تواند خالی باشد.");

    }
}

