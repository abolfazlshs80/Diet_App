using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.disease;
using Diet.Domain.food.Entities;
using ErrorOr;

namespace Diet.Domain.drug.Entities;

/// <summary>
/// دارو
/// </summary>
public sealed class Drug :BaseEntity
{

    private Drug(Guid id, string title, string description) : base(id) { Description = description; Title = title; }
    private Drug(string title, string description) { Description = description; Title = title; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public ICollection<CaseDrug> CaseDrug { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }



    public static ErrorOr<Drug> Create(CreateDrugCommand command)
    {

        var foodGroup = new Drug(command.Title, command.Description);


        return foodGroup;
    }

    public static ErrorOr<Drug> Update(UpdateDrugCommand command)
    {
        var foodGroup = new Drug(command.Id, command.Title, command.Description);


        return foodGroup;
    }


}
