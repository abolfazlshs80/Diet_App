using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;
using ErrorOr;

namespace Diet.Domain.lifeCourse.Entities;
/// <summary>
///   -همراه وعده - نام دوره زندگی 
///    مثلاً "مدرسه"، "امتحانات "، "کنکور"، "بارداری")
/// </summary>
public sealed class LifeCourse: BaseEntity
{
    private LifeCourse()
    {
        
    }
    private LifeCourse(Guid id, string title, Guid parentId) { Id = id; ParentId = parentId; Title = title; }
    public string Title { get;private set; }
    public Guid ParentId { get; private set; }
    public LifeCourse? Parent { get; private set; } // ← Navigation به والد
    public ICollection<LifeCourse> Children { get; private set; } = new List<LifeCourse>(); // ← Navigation به فرزندان

    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }
    public ICollection<RecommendationLifeCourse> RecommendationLifeCourse { get; private set; }

    public ICollection<Case.Case> Case { get; set; }

    public static ErrorOr<LifeCourse> Create(CreateLifeCourseCommand command)
    {

        return new LifeCourse(Guid.NewGuid(), command.Title, command.ParentId);

        
    }

    public static ErrorOr<LifeCourse> Update(LifeCourse lifeCourse,UpdateLifeCourseCommand command)
    {
        return new LifeCourse(lifeCourse.Id, command.Title, command.ParentId);


    }
}
