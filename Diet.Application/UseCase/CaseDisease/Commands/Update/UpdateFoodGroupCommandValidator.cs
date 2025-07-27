

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseDiseaseCommandValidator : AbstractValidator<UpdateCaseDiseaseCommand>
{
    public UpdateCaseDiseaseCommandValidator()
    {
        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.DiseaseId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

