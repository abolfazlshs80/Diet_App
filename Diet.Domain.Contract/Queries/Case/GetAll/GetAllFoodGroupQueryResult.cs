using Diet.Domain.Contract.Enums;
using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Case.GetAll;

public record GetAllCaseQueryResult(int TotalRecords, List<GetCaseItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseItem(
    Guid Id,
    double Weight,
    double Height,
    string BirthDate,
    string Description,
    Gender Gender,
    BodyActivity BodyActivity,
    bool IsSport,
    ExerciseSeverity SportActivity,
    WeightChangeType ChangeWeightType,
    int? WeightChangeAmount,
    int ExerciseTime,
    Guid? SportId,
    

    ExerciseDay ExerciseDay,
    DateTime DateOfStart,
    BodyForm BodyForm,
    Guid LifeCourseId,

    Guid UserId,

    Guid TransactionId
) ;


