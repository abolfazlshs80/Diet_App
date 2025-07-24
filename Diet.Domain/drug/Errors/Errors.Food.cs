
using ErrorOr;


namespace Drug.Domain.Drug.Errors;


public static partial class DomainErrors
{
    public static class Drug_Error
    {
        public static Error Drug_Incorrect => Error.Unexpected(
            code: "Drug.Incorrect",
            description: "Drug is incorrect");


        public static Error Drug_NotFount => Error.NotFound(
         code: "Drug.NotFount",
         description: "Drug is NotFount");


    }

}


