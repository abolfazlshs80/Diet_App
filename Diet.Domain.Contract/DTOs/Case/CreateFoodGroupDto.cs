using Diet.Domain.Contract.Enums;
using Order.Framework.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.Case
{

    public record UpdateCaseDto(
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
    Guid Id,

    ExerciseDay ExerciseDay,
    DateTime DateOfStart,
    BodyForm BodyForm,
    Guid LifeCourseId,

    Guid UserId,

    Guid TransactionId
);

    public record CreateCaseDto(
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
);
    public record DeleteCaseDto(Guid Id);
    public record GetCaseDto(Guid Id);
    public record GetAllCaseDto(string? search, int CurrentPage = 0, int PageSize = 8);

    public record GetItemCaseDto(Guid Id, float Weight, float Height, string BirthDate, string Description, int Gender, int BodyActivity, bool IsSport, int SportActivity, int ChangeWeightType, int? WeightChangeAmount, int ExerciseTime, Guid SportId, int ExerciseDay, DateTime DateOfStart, int BodyForm, Guid LifeCourseId, Guid UserId, Guid TransactionId);

}
