using Diet.Domain.caseDrug;
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
    private Drug()   {  }
    private Drug(Guid id, string title, string description)  { Id = id; Description = description; Title = title; }

    public string Title { get; private set; }
    public string Description { get; private set; }

    public ICollection<caseDrug. CaseDrug> CaseDrug { get; set; }
    public ICollection<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }



    public static ErrorOr<Drug> Create(CreateDrugCommand command)
    {

        return new Drug(Guid.NewGuid(),command.Title, command.Description);


  
    }

    public static ErrorOr<Drug> Update(Drug drug,UpdateDrugCommand command)
    {
        return new Drug(drug.Id, command.Title, command.Description);


    }


}
