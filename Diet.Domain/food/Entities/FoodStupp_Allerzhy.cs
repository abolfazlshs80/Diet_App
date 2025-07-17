using Diet.Domain.common;

namespace Diet.Domain.food.Entities;
/// <summary>
///  برای نگهداری اطلاعات حساسیت‌های مرتبط با مواد غذایی
/// </summary>
public sealed class FoodStupp_Allerzhy : BaseEntity
{

    public Guid? FoodStuppId { get; private set; }
    public FoodStupp? FoodStupp { get; private set; }
    private FoodStupp_Allerzhy() { }
}
