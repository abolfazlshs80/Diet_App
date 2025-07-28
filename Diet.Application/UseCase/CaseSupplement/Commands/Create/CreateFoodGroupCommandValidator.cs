

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseSupplementCommandValidator : AbstractValidator<CreateCaseSupplementCommand>
{
    public CreateCaseSupplementCommandValidator()
    {
        RuleFor(x => x.CaseId)
           .NotNull().WithMessage("شناسه پرونده نمی‌تواند تهی باشد.")
           .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.SupplementId)
            .NotNull().WithMessage("شناسه مکمل نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند خالی باشد.");


    }
}

