using Diet.Domain.Contract.Queries.CaseDisease.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDisease.Queries.GetById;

public class GetByIdCaseDiseaseQueryValidator : AbstractValidator<GetByIdCaseDiseaseQuery>
{
    public GetByIdCaseDiseaseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

