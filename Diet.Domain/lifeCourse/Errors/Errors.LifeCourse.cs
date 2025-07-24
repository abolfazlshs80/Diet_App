
using ErrorOr;


namespace Drug.Domain.Drug.Errors;



 public static partial class DomainErrors
{
    public static class LifeCourse_Error
    {
        public static Error LifeCourse_Incorrect => Error.Unexpected(
            code: "lifeCourse.Incorrect",
            description: "lifeCourse is incorrect");


        public static Error LifeCourse_NotFount => Error.NotFound(
         code: "lifeCourse.NotFount",
         description: "lifeCourse is NotFount");


    }

}
