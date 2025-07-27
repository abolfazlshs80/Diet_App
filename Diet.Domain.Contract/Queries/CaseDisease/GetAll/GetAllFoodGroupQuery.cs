using Diet.Domain.Contract.DTOs;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDisease.GetAll;

public record GetAllCaseDiseaseQuery(string? search, int CurrentPage=0, int PageSize=8):  IQuery;

