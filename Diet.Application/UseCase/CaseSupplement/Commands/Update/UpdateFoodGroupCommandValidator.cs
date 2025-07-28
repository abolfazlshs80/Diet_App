

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseSupplementCommandValidator : AbstractValidator<UpdateCaseSupplementCommand>
{
    public UpdateCaseSupplementCommandValidator()
    {
        RuleFor(x => x.CaseId)
                   .NotNull().WithMessage("شناسه پرونده نمی‌تواند تهی باشد.")
                   .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.SupplementId)
            .NotNull().WithMessage("شناسه مکمل نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نمی‌تواند خالی باشد.");


    }
}

