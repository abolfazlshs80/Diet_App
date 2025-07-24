
using Diet.Domain.Contract.Queries.Drug.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.Drug.Queries.GetAll;

public class GetAllDrugQueryValidator : AbstractValidator<GetAllDrugQuery>
{
    public GetAllDrugQueryValidator()
    {
     

    }
}

