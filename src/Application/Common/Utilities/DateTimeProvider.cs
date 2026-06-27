namespace Application.Common.Utilities;

public static class DateTimeProvider
{
    public static DateTime UtcNow => DateTime.UtcNow;

    public static DateOnly Today =>
        DateOnly.FromDateTime(DateTime.Today);
}