

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodDrugIntractionCommandValidator : AbstractValidator<UpdateFoodDrugIntractionCommand>
{
    public UpdateFoodDrugIntractionCommandValidator()
    {
        RuleFor(x => x.FoodId).NotNull().NotEmpty();
        RuleFor(x => x.DrugId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

