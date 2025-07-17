


using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using Diet.Domain.disease;
using Diet.Domain.lifeCourse;
using Diet.Domain.supplement;
using Diet.Domain.user;
using Diet.Domain.weightGoal;
using System.Collections.ObjectModel;

namespace Diet.Domain.Case;

public sealed class Case :BaseEntity
{

    private Case() { }


    public string Description { get; private  set; }

    public Gender Gender { get; private set; }
    public BodyForm BodyForm { get; private set; }
    public Guid lifeCourseId { get; private set; }
    public Guid DiseaseId { get; private set; }
    public  Disease Disease { get; private set; }
    public Guid weightGoalId { get; private set; }
    public WeightGoal weightGoal { get; private set; }
    public ICollection<Drug> Drug { get; private set; }
    public List<Guid> SupplementAlerzhy { get; private set; }

    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string BirthDate { get; private set; }
    public int? PRC { get; private set; }
    public double CaloryValue { get; private set; }

    public Guid? SportTypeId { get; private set; }
    public int? SportTypeDuration { get; private set; }


    public Guid TransactionId { get; private set; }
}
