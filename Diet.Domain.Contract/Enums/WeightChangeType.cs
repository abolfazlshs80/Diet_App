namespace Diet.Domain.Contract.Enums
{
    /// <summary>
    /// نوع تغییر وزن
    /// </summary>
    public enum WeightChangeType
    {
        WEIGHTLOSSWITHOUTSPORT, // کاهش وزن بدون ورزش
        WEIGHTLOSSWITHSPORT,// کاهش وزن با ورزش
        WEIGHTGAINWITHBODYBUILDING,// افزایش وزن با بدنسازی
        WEIGHTGAINWITHOUTBODYBUILDING, // افزایش وزن بدون بدنسازی
        WEIGHTFIXED // تثبیت وزن
    }
}
