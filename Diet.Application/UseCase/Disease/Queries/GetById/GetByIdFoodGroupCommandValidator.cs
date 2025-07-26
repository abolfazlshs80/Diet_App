using Diet.Domain.Contract.Queries.Disease.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.Disease.Queries.GetById;

public class GetByIdDiseaseQueryValidator : AbstractValidator<GetByIdDiseaseQuery>
{
    public GetByIdDiseaseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

