using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementGroup.GetAll;
namespace Diet.Application.UseCase.SupplementGroup.Queries.GetAll;

public class GetAllSupplementGroupQueryValidator : AbstractValidator<GetAllSupplementGroupQuery>
{
    public GetAllSupplementGroupQueryValidator()
    {
        
    }
}
