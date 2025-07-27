using Diet.Domain.Contract.Enums;
using Order.Framework.Core.Bus;
using System.Transactions;

namespace Diet.Domain.Contract.Queries.Case.GetById;


public record GetByIdCaseQueryResult(
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
    Guid? Id,
   
    ExerciseDay ExerciseDay,
    DateTime DateOfStart,
    BodyForm BodyForm,
    Guid LifeCourseId,
  
    Guid UserId,

    Guid TransactionId
): IQueryResult;
