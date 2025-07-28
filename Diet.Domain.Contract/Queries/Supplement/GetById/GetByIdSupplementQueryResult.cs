using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Supplement.GetById;

public record GetByIdSupplementQueryResult(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId) : IQueryResult;
