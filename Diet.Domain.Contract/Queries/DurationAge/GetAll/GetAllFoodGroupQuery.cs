using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetAll;

public record GetAllDurationAgeQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

