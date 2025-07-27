using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetAll;

public record GetAllCaseFoodStuffAllergyQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

