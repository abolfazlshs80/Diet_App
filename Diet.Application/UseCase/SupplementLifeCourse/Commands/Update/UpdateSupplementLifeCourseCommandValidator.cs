using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
namespace Diet.Domain.UseCase.SupplementLifeCourse.Commands.Create
{
    public class UpdateSupplementLifeCourseCommandValidator : AbstractValidator<UpdateSupplementLifeCourseCommand>
    {
        public UpdateSupplementLifeCourseCommandValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.LifeCourseId)
                .NotEmpty().WithMessage("شناسه دوره زندگی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
