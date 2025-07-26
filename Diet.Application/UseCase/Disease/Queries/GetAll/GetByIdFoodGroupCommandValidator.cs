
using Diet.Domain.Contract.Queries.Disease.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.Disease.Queries.GetAll;

public class GetAllDiseaseQueryValidator : AbstractValidator<GetAllDiseaseQuery>
{
    public GetAllDiseaseQueryValidator()
    {
     

    }
}

