namespace Diet.Domain.Contract.ViewModels.DurationAge;

public record CreateDurationAgeViewModel(string D_Title, int D_MinAge, int D_MaxAge);
public record GetDurationAgeViewModel(Guid D_Id, string D_Title, int D_MinAge, int D_MaxAge);
public record GetItemDurationAgeViewModel(Guid D_Id);

