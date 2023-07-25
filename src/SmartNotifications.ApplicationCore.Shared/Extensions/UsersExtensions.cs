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