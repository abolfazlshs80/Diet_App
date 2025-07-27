using Diet.Domain.common;
using ErrorOr;

namespace Diet.Domain.sport;

public sealed class Sport: BaseEntity
{

    private Sport() { }

    public string Name { get; set; }
    public int Low { get; set; }
    public int Medium { get; set; }
    public int High { get; set; }
    public ICollection<Case.Case> Case { get; set; }


    private Sport(Guid id, string name, int low, int medium, int high)
    {
        Id = id;
        Name = name;
        Low = low;
        Medium = medium;
        High = high;
    }

    //public static ErrorOr<Diet.Domain.sport.Sport> Create(CreateSportCommand command)
    //{
    //    return new Sport(
    //        Guid.NewGuid(),
    //        command.Name,
    //        command.Low,
    //        command.Medium,
    //        command.High
    //    );
    //}

    //public static ErrorOr<Diet.Domain.sport.Sport> Update(Sport existing, UpdateSportCommand command)
    //{
    //    return new Sport(
    //        existing.Id,
    //        command.Name,
    //        command.Low,
    //        command.Medium,
    //        command.High
    //    );
    //}

}
