using Diet.Domain.common;

namespace Diet.Domain.supplement.Entities;
/// <summary>
/// مدل  برای نگهداری اطلاعات حساسیت به مکمل‌های 
/// </summary>
public class SupplementAlerzhy : BaseEntity
{
    private SupplementAlerzhy() { }
    public string Title { get; private set; }
    
}
