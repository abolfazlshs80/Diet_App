using Diet.Domain.@case.Entities;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using Diet.Domain.food.Entities;
using Diet.Domain.lifeCourse;
using Diet.Domain.sport;
using Diet.Domain.transactions;
using Diet.Domain.user;
using Diet.Domain.user.Entities;
using System.Transactions;

namespace Diet.Domain.Case;

public sealed  class Case :BaseEntity
{

    private Case() { }

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

    public ICollection<CaseDrug> CaseDrug { get; private set; }//لیست داروهای فرد
    public ICollection<CaseDisease> Disease { get; private set; }//لیست بیماری های فرد
    public ICollection<CaseSupplement> CaseSupplement { get; private set; }//لیست مکمل های فرد
    public ICollection<CaseFoodStuffAllergy> FoodStuffAllergy { get; private set; }//لیست های آلرژی ها فرد ماده غذایی
    public ICollection<CasePleasantFood> PleasantFood { get; private set; }//غذاهای خوشایند فرد
    public ICollection<CaseUnPleasantFood> UnPleasantFood { get; private set; }//غذا های نا خوشایند





    public Guid TransactionId { get; private set; }
    public Transactions Transactions { get; private set; }
}
