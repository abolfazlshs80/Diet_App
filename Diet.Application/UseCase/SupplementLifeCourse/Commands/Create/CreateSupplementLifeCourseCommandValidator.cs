using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
namespace Diet.Domain.UseCase.SupplementLifeCourse.Commands.Create
{
    public class CreateSupplementLifeCourseCommandValidator : AbstractValidator<CreateSupplementLifeCourseCommand>
    {
        public CreateSupplementLifeCourseCommandValidator()
        {
            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.LifeCourseId)
                .NotEmpty().WithMessage("شناسه دوره زندگی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
