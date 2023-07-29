using SCM.SmartNotifications.ApplicationCore.Shared.Services;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface IExpressionEvaluator
{
    Task<Dictionary<string, object>> EvaluateAsync(Dictionary<string, object> parameters, GlobalContext context,
        CancellationToken cancellationToken);

    Task<object> EvaluateAsync(object expression, GlobalContext context, CancellationToken cancellationToken);
}