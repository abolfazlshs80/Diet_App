

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseDiseaseCommandValidator : AbstractValidator<UpdateCaseDiseaseCommand>
{
    public UpdateCaseDiseaseCommandValidator()
    {
        RuleFor(x => x.CaseId)
         .NotNull().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.")
         .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.DiseaseId)
            .NotNull().WithMessage("شناسه بیماری نمی‌تواند خالی باشد.")
            .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه نمی‌تواند خالی باشد.")
            .NotEmpty().WithMessage("شناسه نمی‌تواند خالی باشد.");

    }
}

