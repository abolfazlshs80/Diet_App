using FluentValidation;
using Diet.Domain.Contract.Queries.Sport.GetAll;
namespace Diet.Application.UseCase.Sport.Queries.GetAll;

public class GetAllSportQueryValidator : AbstractValidator<GetAllSportQuery>
{
    public GetAllSportQueryValidator()
    {
        
    }
}
