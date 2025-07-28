using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetAll;
namespace Diet.Application.UseCase.SupplementDurationAge.Queries.GetAll;

public class GetAllSupplementDurationAgeQueryValidator : AbstractValidator<GetAllSupplementDurationAgeQuery>
{
    public GetAllSupplementDurationAgeQueryValidator()
    {
        
    }
}
