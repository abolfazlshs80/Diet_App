using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetAll;
namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Queries.GetAll;

public class GetAllSupplementDisease_WhiteListQueryValidator : AbstractValidator<GetAllSupplementDisease_WhiteListQuery>
{
    public GetAllSupplementDisease_WhiteListQueryValidator()
    {
        
    }
}
