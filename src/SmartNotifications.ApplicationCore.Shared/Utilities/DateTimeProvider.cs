namespace SCM.SmartNotifications.ApplicationCore.Shared.Utilities;

public static class DateTimeProvider
{
    public static DateTime UtcNow
        => DateTimeProviderContext.Current == null
            ? DateTime.UtcNow
            : DateTimeProviderContext.Current.ContextDateTimeNow;

    public static bool IsNull(this DateTime? date)
    {
        if (!date.HasValue)
            return true;

        return date == DateTime.MinValue;
    }
}