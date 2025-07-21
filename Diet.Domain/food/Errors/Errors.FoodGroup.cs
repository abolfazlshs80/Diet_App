
using ErrorOr;


namespace FoodGroup.Domain.FoodGroup.Errors;


public static partial class DomainErrors
{
    public static class FoodGroup_Error
    {
        public static Error FoodGroup_Incorrect => Error.Unexpected(
            code: "FoodGroup.Incorrect",
            description: "FoodGroup is incorrect");


        public static Error FoodGroup_NotFount => Error.NotFound(
         code: "FoodGroup.NotFount",
         description: "FoodGroup is NotFount");


    }

}


