using System.ComponentModel.DataAnnotations;

namespace Diet.Domain.Contract.Enums
{
    public enum CaseType
    {
        [Display(Name = "انتخاب نشده")]
        None,
        [Display(Name = "هفتگی")]
        Weekly,
        [Display(Name = "منو")]
        Menu,
        [Display(Name = "ترکیبی")]
        Complex,
    }
}
