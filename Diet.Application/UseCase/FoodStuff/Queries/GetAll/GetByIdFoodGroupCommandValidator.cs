
using Diet.Domain.Contract.Queries.FoodStuff.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.FoodStuff.Queries.GetAll;

public class GetAllFoodStuffQueryValidator : AbstractValidator<GetAllFoodStuffQuery>
{
    public GetAllFoodStuffQueryValidator()
    {
     

    }
}

