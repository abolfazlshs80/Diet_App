using System;

namespace Diet.Framework.Core.Utility;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
