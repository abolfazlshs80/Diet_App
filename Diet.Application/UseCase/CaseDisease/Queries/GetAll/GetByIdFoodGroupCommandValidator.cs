
using Diet.Domain.Contract.Queries.CaseDisease.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDisease.Queries.GetAll;

public class GetAllCaseDiseaseQueryValidator : AbstractValidator<GetAllCaseDiseaseQuery>
{
    public GetAllCaseDiseaseQueryValidator()
    {
     

    }
}

