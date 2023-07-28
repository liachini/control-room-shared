using System.Globalization;
using SCM.SmartNotifications.ApplicationCore.Shared.Services;

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

public static class UrlExtensions
{
    public static async Task<Url> EvaluateAsync(this Url url, IExpressionEvaluator expressionEvaluator, GlobalContext globalContext, CancellationToken cancellationToken)
    {
        return url with
        {
            Parameters = await expressionEvaluator.EvaluateAsync(url.Parameters, globalContext, cancellationToken),
            Headers = await expressionEvaluator.EvaluateAsync(url.Headers, globalContext, cancellationToken),
        };
    }

}