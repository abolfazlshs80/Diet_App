using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
namespace Diet.Domain.UseCase.SupplementDisease_WhiteList.Commands.Create
{
    public class CreateSupplementDisease_WhiteListCommandValidator : AbstractValidator<CreateSupplementDisease_WhiteListCommand>
    {
        public CreateSupplementDisease_WhiteListCommandValidator()
        {

            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DiseaseId)
                .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
