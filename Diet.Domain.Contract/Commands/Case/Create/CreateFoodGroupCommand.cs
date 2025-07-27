

using Diet.Domain.Contract.Enums;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Order.Create;

public record CreateCaseCommand    (
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
Guid SportId,


ExerciseDay ExerciseDay,
DateTime DateOfStart,
BodyForm BodyForm,
Guid LifeCourseId,

Guid UserId,

Guid TransactionId
): ICommand;
 