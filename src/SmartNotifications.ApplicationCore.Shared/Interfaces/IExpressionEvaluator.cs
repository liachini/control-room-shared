namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface IExpressionEvaluator
{
    Task<Dictionary<string, object>> EvaluateAsync(Dictionary<string, object> parameters, object context,
        CancellationToken cancellationToken);

    Task<object> EvaluateAsync(object expression, object context, CancellationToken cancellationToken);
}