
using ErrorOr;


namespace Disease.Domain.Disease.Errors;


public static partial class DomainErrors
{
    public static class Disease_Error
    {
        public static Error Disease_Incorrect => Error.Unexpected(
            code: "Disease.Incorrect",
            description: "Disease is incorrect");


        public static Error Disease_NotFount => Error.NotFound(
         code: "Disease.NotFount",
         description: "Disease is NotFount");


    }

}


