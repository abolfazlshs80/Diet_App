using Diet.Domain.caseDisease;
using Diet.Domain.caseDrug;
using Diet.Domain.caseFoodStuffAllergy;
using Diet.Domain.casePleasantFood;
using Diet.Domain.caseSupplement;
using Diet.Domain.caseUnPleasantFood;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Enums;
using Diet.Domain.food.Entities;
using Diet.Domain.lifeCourse.Entities;
using Diet.Domain.sport;
using Diet.Domain.transactions;
using Diet.Domain.user;
using Diet.Domain.user.Entities;
using ErrorOr;
using System.Reflection;
using System.Transactions;

namespace Diet.Domain.Case;

public sealed  class Case :BaseEntity
{

    private Case() { }

    private Case(
    Guid id,
    double weight,
    double height,
    string birthDate,
    string description,
    Gender gender,
    BodyActivity bodyActivity,
    bool isSport,
    ExerciseSeverity sportActivity,
    WeightChangeType changeWeightType,
    int? weightChangeAmount,
    int exerciseTime,
    Guid? sportId,
  
    ExerciseDay exerciseDay,
    DateTime dateOfStart,
    BodyForm bodyForm,
    Guid lifeCourseId,

    Guid userId,

    Guid transactionId
)
    {
        Id = id;
        Weight = weight;
        Height = height;
        BirthDate = birthDate;
        Description = description;
        Gender = gender;
        BodyActivity = bodyActivity;
        IsSport = isSport;
        SportActivity = sportActivity;
        ChangeWeightType = changeWeightType;
        WeightChangeAmount = weightChangeAmount;
        ExerciseTime = exerciseTime;
        SportId = sportId;
       
        ExerciseDay = exerciseDay;
        DateOfStart = dateOfStart;
        BodyForm = bodyForm;
        LifeCourseId = lifeCourseId;
       
        UserId = userId;
        
        TransactionId = transactionId;
       
    }

    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string BirthDate { get; private set; }
    public string Description { get; private  set; }
    public Gender Gender { get; private set; }
    public BodyActivity BodyActivity { get; private set; }
     
    public bool IsSport { get; private set; } = false;

    public ExerciseSeverity SportActivity { get; private set; } // شدت ورزش
    public WeightChangeType ChangeWeightType { get; private set; } // تغییر وزن 
    public int? WeightChangeAmount { get; private set; } // مقدار وزن -- برای کاهش وزن حداکثر 4 کیلو در ماه  بیشتر از 4 کیلو سیستم باید بهش هشدار بدهد


    public int ExerciseTime { get; set; }// مقدار ورزش به دقیقه

    public Guid? SportId { get; private set; }
    public Sport Sport { get; private set; } // دوره زندگی فرد
    public ExerciseDay ExerciseDay { get; private set; }//زمان انجام ورزش در روز

    public DateTime DateOfStart { get; set; }//تاریخ شروع برنامه غذایی

    public BodyForm BodyForm { get; private set; } // فرم بدن فعلی فرد
    public Guid LifeCourseId { get; private set; }
    public LifeCourse LifeCourse { get; private set; } // دوره زندگی فرد


    public Guid UserId { get; private set; }
    public User User { get; private set; } // دوره زندگی فرد

    public ICollection<caseDrug.CaseDrug> CaseDrug { get; private set; }//لیست داروهای فرد
    public ICollection<Domain.caseDisease. CaseDisease> Disease { get; private set; }//لیست بیماری های فرد
    public ICollection<caseSupplement. CaseSupplement> CaseSupplement { get; private set; }//لیست مکمل های فرد
    public ICollection<caseFoodStuffAllergy.CaseFoodStuffAllergy> FoodStuffAllergy { get; private set; }//لیست های آلرژی ها فرد ماده غذایی
    public ICollection<casePleasantFood. CasePleasantFood> PleasantFood { get; private set; }//غذاهای خوشایند فرد
    public ICollection<caseUnPleasantFood.CaseUnPleasantFood > UnPleasantFood { get; private set; }//غذا های نا خوشایند





    public Guid TransactionId { get; private set; }
    public Transactions Transactions { get; private set; }

    public static ErrorOr<Case> Update(Case curentmodel, UpdateCaseCommand model)
    {
        if (model.WeightChangeAmount.HasValue &&
            model.WeightChangeAmount > 4 )
        {
            return Error.Validation("WeightChangeAmount", "مقدار کاهش وزن نباید بیش از ۴ کیلو در ماه باشد.");
        }

        var updated = new Case(
           curentmodel.Id,
            model.Weight,
            model.Height,
            model.BirthDate,
            model.Description,
            model.Gender,
            model.BodyActivity,
            model.IsSport,
            model.SportActivity,
            model.ChangeWeightType,
            model.WeightChangeAmount,
            model.ExerciseTime,
            model.SportId,
          
            model.ExerciseDay,
            model.DateOfStart,
            model.BodyForm,
            model.LifeCourseId,
           
            model.UserId,
            
            model.TransactionId
          );

        return updated;
    }

    public static ErrorOr<Case> Create( CreateCaseCommand model)
    {
        var updated = new Case(
         Guid.NewGuid(),
         model.Weight,
         model.Height,
         model.BirthDate,
         model.Description,
         model.Gender,
         model.BodyActivity,
         model.IsSport,
         model.SportActivity,
         model.ChangeWeightType,
         model.WeightChangeAmount,
         model.ExerciseTime,
         model.SportId,

         model.ExerciseDay,
         model.DateOfStart,
         model.BodyForm,
         model.LifeCourseId,

         model.UserId,

         model.TransactionId
    );
        return updated;

    }
}
