

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseDrugCommandValidator : AbstractValidator<UpdateCaseDrugCommand>
{
    public UpdateCaseDrugCommandValidator()
    {
        RuleFor(x => x.CaseId)
                  .NotNull().WithMessage("شناسه پرونده نمی‌تواند null باشد.")
                  .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.DrugId)
            .NotNull().WithMessage("شناسه دارو نمی‌تواند null باشد.")
            .NotEmpty().WithMessage("شناسه دارو نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نمی‌تواند null باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نمی‌تواند خالی باشد.");

    }
}

