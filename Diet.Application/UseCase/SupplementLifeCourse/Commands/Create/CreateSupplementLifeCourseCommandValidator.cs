using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
namespace Diet.Domain.UseCase.SupplementLifeCourse.Commands.Create
{
    public class CreateSupplementLifeCourseCommandValidator : AbstractValidator<CreateSupplementLifeCourseCommand>
    {
        public CreateSupplementLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
