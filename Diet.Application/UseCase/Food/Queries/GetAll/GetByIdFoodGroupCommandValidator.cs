
using Diet.Domain.Contract.Queries.Food.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.Food.Queries.GetAll;

public class GetAllFoodQueryValidator : AbstractValidator<GetAllFoodQuery>
{
    public GetAllFoodQueryValidator()
    {
     

    }
}

