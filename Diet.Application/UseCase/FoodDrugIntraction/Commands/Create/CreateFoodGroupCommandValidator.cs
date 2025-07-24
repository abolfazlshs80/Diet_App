

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodDrugIntractionCommandValidator : AbstractValidator<CreateFoodDrugIntractionCommand>
{
    public CreateFoodDrugIntractionCommandValidator()
    {
        RuleFor(x => x.FoodId).NotNull().NotEmpty();
        RuleFor(x => x.DrugId).NotNull().NotEmpty();
       

    }
}

