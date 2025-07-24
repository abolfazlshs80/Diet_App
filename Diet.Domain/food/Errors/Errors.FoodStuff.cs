
using ErrorOr;


namespace FoodStuff.Domain.FoodStuff.Errors;


public static partial class DomainErrors
{
    public static class FoodStuff_Error
    {
        public static Error FoodStuff_Incorrect => Error.Unexpected(
            code: "FoodStuff.Incorrect",
            description: "FoodStuff is incorrect");


        public static Error FoodStuff_NotFount => Error.NotFound(
         code: "FoodStuff.NotFount",
         description: "FoodStuff is NotFount");


    }

}


