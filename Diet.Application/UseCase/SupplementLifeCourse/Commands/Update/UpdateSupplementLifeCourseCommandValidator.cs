using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
namespace Diet.Domain.UseCase.SupplementLifeCourse.Commands.Create
{
    public class UpdateSupplementLifeCourseCommandValidator : AbstractValidator<UpdateSupplementLifeCourseCommand>
    {
        public UpdateSupplementLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
