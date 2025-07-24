
using ErrorOr;


namespace Drug.Domain.Drug.Errors
{

    public static partial class DomainErrors
    {
        public static class DurationAge_Error
        {
            public static Error DurationAge_Incorrect => Error.Unexpected(
                code: "DurationAge.Incorrect",
                description: "DurationAge is incorrect");


            public static Error DurationAge_NotFount => Error.NotFound(
             code: "DurationAge.NotFount",
             description: "DurationAge is NotFount");


        }

    }


}
