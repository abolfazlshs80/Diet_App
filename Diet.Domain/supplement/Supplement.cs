﻿using Diet.Domain.caseSupplement;
using Diet.Domain.common;

namespace Diet.Domain.supplement.Entities;
/// <summary>
///    نمایانگر یک مکمل غذایی است.
/// </summary>
public sealed class Supplement:BaseEntity
{
    private Supplement() { }
    public string? Title { get;private set; }
    public string? EnglishTitle { get; private set; }
    public string? Description { get; private set; }
    public string? HowToUse { get; private set; }

    public ICollection<CaseSupplement> CaseSupplement { get; set; }
    public Guid SupplementGroupId { get; private set; }
    public  SupplementGroup SupplementGroup { get; private set; }
    public ICollection< SupplementDisease_WhiteList> SupplementDisease_WhiteList  { get; private set; }
    public ICollection<SupplementDurationAge> SupplementDurationAge { get; private set; }
    public ICollection<SupplementLifeCourse> SupplementLifeCourse { get; private set; }
}
