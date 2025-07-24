using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.FoodFoodIntraction.Queries.GetById;

public class GetByIdFoodFoodIntractionQueryValidator : AbstractValidator<GetByIdFoodFoodIntractionQuery>
{
    public GetByIdFoodFoodIntractionQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

