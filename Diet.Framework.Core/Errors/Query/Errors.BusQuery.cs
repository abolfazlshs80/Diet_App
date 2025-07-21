using Diet.Framework.Core.Bus;
using ErrorOr;
using Order.Framework.Core.Bus;

namespace Diet.Framework.Core.Errors;

public static partial class BusErrors 
{
    public static class Query
    {
        public static Error IQueryHandlerIsNull => Error.Unexpected(
            code: "IQueryHandler.Null",
            description: "IQueryHandler Is Null");

        public static Error IValidationQueryHandlerIsFalse(IQuery Query) => Error.Unexpected(
           code: "IValidationQueryHandler.False",
           description: "" + Query.GetType().ToString() + " Validation Is False");
        public static Error IAuthorizeQueryHandlerDeny(IQuery Query) => Error.Unexpected(
         code: "IAuthorizeQueryHandler.Deny",
         description: "" + Query.GetType().ToString() + " Authorize Is Deny");

    }
}
