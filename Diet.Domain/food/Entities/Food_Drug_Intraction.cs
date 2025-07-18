﻿using Diet.Domain.common;
using Diet.Domain.user;

namespace Diet.Domain.food.Entities;
/// <summary>
/// این مدل مسئول شناسایی و
/// مدیریت تداخلات احتمالی بین غذاها و داروهاست.
/// </summary>
public sealed class Food_Drug_Intraction : BaseEntity
{
    private Food_Drug_Intraction() { }
    public Guid FoodId { get; private set; }
    public Food Food { get; private set; }

    public Guid DrugId { get; private set; }
    public Drug Drug { get; private set; }


}
