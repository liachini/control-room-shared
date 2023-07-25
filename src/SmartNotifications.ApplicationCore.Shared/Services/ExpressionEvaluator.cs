using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

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
            if (keyValuePair.Value.IsScript())
            {
                results[keyValuePair.Key] =
                    (await EvaluateAsync(keyValuePair.Value, context, cancellationToken))
                    .ToString();
                continue;
            }

            results[keyValuePair.Key] = keyValuePair.Value.ToString();
        }

        return results;
    }

    public async Task<object> EvaluateAsync(object expression, object context, CancellationToken cancellationToken)
    {
        if (!expression.IsScript()) return expression;

        return await _scriptEngine.EvaluateAsync<object>(expression.ToExpression(), context, cancellationToken);
    }


}