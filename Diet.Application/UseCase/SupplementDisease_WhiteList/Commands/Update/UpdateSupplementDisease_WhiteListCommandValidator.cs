using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
namespace Diet.Domain.UseCase.SupplementDisease_WhiteList.Commands.Create
{
    public class UpdateSupplementDisease_WhiteListCommandValidator : AbstractValidator<UpdateSupplementDisease_WhiteListCommand>
    {
        public UpdateSupplementDisease_WhiteListCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DiseaseId)
                .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
