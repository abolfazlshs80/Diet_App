
using ErrorOr;


namespace FoodDrugIntraction.Domain.FoodDrugIntraction.Errors;


public static partial class DomainErrors
{
    public static class FoodDrugIntraction_Error
    {
        public static Error FoodDrugIntraction_Incorrect => Error.Unexpected(
            code: "FoodDrugIntraction.Incorrect",
            description: "FoodDrugIntraction is incorrect");


        public static Error FoodDrugIntraction_NotFount => Error.NotFound(
         code: "FoodDrugIntraction.NotFount",
         description: "FoodDrugIntraction is NotFount");


    }

}


