using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Delete;
namespace Diet.Domain.UseCase.SupplementLifeCourse.Commands.Create
{
    public class DeleteSupplementLifeCourseCommandValidator : AbstractValidator<DeleteSupplementLifeCourseCommand>
    {
        public DeleteSupplementLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
