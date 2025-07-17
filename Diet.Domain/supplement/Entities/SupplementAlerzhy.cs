using Diet.Domain.common;

namespace Diet.Domain.supplement.Entities;
/// <summary>
/// مدل  برای نگهداری اطلاعات حساسیت به مکمل‌های 
/// </summary>
public class SupplementAlerzhy : BaseEntity
{
    private SupplementAlerzhy() { }
    public string Title { get; set; }
    
}

/// <summary>
/// مدل  برای نگهداری اطلاعات حساسیت به مکمل‌های 
/// </summary>
public sealed class SupplementAlerzhy_Supplement : BaseEntity
{
    private SupplementAlerzhy_Supplement() { }

    public Guid SupplementAlerzhyId { get; private set; }
    public SupplementAlerzhy SupplementAlerzhy { get; private set; }
    public Guid SupplementId { get; private set; }
    public Supplement Supplement { get; private set; }

}