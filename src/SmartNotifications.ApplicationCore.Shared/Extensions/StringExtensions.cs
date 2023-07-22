using System.Globalization;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

public static class UsersExtensions
{
    public static IEnumerable<IGrouping<CultureInfo, User>> GroupByCulture(this IEnumerable<User> users)
    {
        IEnumerable<User> userModels = users
            .Where(u => !string.IsNullOrEmpty(u.Email)); //.DistinctBy(model => model.Email);

        IEnumerable<IGrouping<CultureInfo, User>> cultureGroups = userModels.GroupBy(u => u.Language);
        return cultureGroups;
    }
}

public static class StringExtensions
{
    public static bool IsNumber(this string value)
    {
        return double.TryParse(value, out _);
    }

    public static string RemoveStringFromBeginning(this string sourceString, string removeString)
    {
        int index = sourceString.IndexOf(removeString);
        return index < 0
            ? sourceString
            : sourceString.Remove(index, removeString.Length);
    }
}