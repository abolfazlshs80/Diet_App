using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.FoodDrugIntraction.Queries.GetById;

public class GetByIdFoodDrugIntractionQueryValidator : AbstractValidator<GetByIdFoodDrugIntractionQuery>
{
    public GetByIdFoodDrugIntractionQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
 

    }
}

