namespace Diet.Domain.Contract.Enums
{
    /// <summary>
    /// نوع تغییر وزن
    /// </summary>
    public enum WeightChangeType
    {
        WeightLossWithOutSport, // کاهش وزن بدون ورزش
        WeightLossWithSport,// کاهش وزن با ورزش
        WeightGainWithBodyBuilding,// افزایش وزن با بدنسازی
        WeightGainWithoutBodyBuilding, // افزایش وزن بدون بدنسازی
        WeightFixed // تثبیت وزن
    }
}
