namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public class ExpressionEvaluator : IExpressionEvaluator
{
    private readonly IScriptEngine _scriptEngine;

    public ExpressionEvaluator(IScriptEngine scriptEngine)
    {
        _scriptEngine = scriptEngine;
    }

    public async Task<Dictionary<string, object>> EvaluateAsync(Dictionary<string, object> parameters, object context,
        CancellationToken cancellationToken)
    {
        Dictionary<string, object> results = new Dictionary<string, object>();

        foreach (KeyValuePair<string, object> keyValuePair in parameters)
        {
            if (IsScript(keyValuePair.Value))
            {
                results[keyValuePair.Key] =
                    (await EvaluateAsync(keyValuePair.Value.ToString()[1..], context, cancellationToken))
                    .ToString();
                continue;
            }

            results[keyValuePair.Key] = keyValuePair.Value.ToString();
        }

        return results;
    }

    public Task<object> EvaluateAsync(string expression, object context, CancellationToken cancellationToken)
    {
        return _scriptEngine.EvaluateAsync<object>(expression, context, cancellationToken);
    }

    private static bool IsScript(object value)
    {
        return Convert.ToString(value)!.StartsWith("@");
    }
}