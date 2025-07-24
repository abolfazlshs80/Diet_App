
using ErrorOr;


namespace Food.Domain.Food.Errors;


public static partial class DomainErrors
{
    public static class Food_Error
    {
        public static Error Food_Incorrect => Error.Unexpected(
            code: "Food.Incorrect",
            description: "Food is incorrect");


        public static Error Food_NotFount => Error.NotFound(
         code: "Food.NotFount",
         description: "Food is NotFount");


    }

}


