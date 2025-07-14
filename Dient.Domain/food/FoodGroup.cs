

using Dient.Domain.common;
using Diet.Domain.supplement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Domain.food;

public class FoodGroup : BaseEntity
{
    public string Title { get; set; }

    private FoodGroup(){}
}
