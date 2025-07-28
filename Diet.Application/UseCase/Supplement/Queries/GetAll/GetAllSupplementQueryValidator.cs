using FluentValidation;
using Diet.Domain.Contract.Queries.Supplement.GetAll;
namespace Diet.Application.UseCase.Supplement.Queries.GetAll;

public class GetAllSupplementQueryValidator : AbstractValidator<GetAllSupplementQuery>
{
    public GetAllSupplementQueryValidator()
    {
        
    }
}
