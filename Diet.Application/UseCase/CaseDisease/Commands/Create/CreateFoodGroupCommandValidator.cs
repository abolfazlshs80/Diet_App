using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDisease.Commands.Create;

public class CreateCaseDiseaseCommandValidator : AbstractValidator<CreateCaseDiseaseCommand>
{
    public CreateCaseDiseaseCommandValidator()
    {
        RuleFor(x => x.CaseId)
    .NotNull().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.")
    .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.DiseaseId)
            .NotNull().WithMessage("شناسه بیماری نمی‌تواند خالی باشد.")
            .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند خالی باشد.");

    }
}

