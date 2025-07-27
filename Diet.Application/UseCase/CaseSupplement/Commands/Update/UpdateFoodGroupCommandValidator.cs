

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseSupplementCommandValidator : AbstractValidator<UpdateCaseSupplementCommand>
{
    public UpdateCaseSupplementCommandValidator()
    {
        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.SupplementId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

