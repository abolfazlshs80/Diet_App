
using ErrorOr;


namespace FoodFoodIntraction.Domain.FoodFoodIntraction.Errors;


public static partial class DomainErrors
{
    public static class FoodFoodIntraction_Error
    {
        public static Error FoodFoodIntraction_Incorrect => Error.Unexpected(
            code: "FoodFoodIntraction.Incorrect",
            description: "FoodFoodIntraction is incorrect");


        public static Error FoodFoodIntraction_NotFount => Error.NotFound(
         code: "FoodFoodIntraction.NotFount",
         description: "FoodFoodIntraction is NotFount");


    }

}


