using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public class ExpressionEvaluator : IExpressionEvaluator
{
    private readonly IScriptEngine _scriptEngine;

    public ExpressionEvaluator(IScriptEngine scriptEngine)
    {
        _scriptEngine = scriptEngine;
    }

    #region Public Methods

    public async Task<Dictionary<string, object>> EvaluateAsync(Dictionary<string, object> parameters,
        GlobalContext context,
        CancellationToken cancellationToken)
    {
        if (parameters == null) return new Dictionary<string, object>();

        Dictionary<string, object> results = new Dictionary<string, object>();

        dynamic dynamicContext = BuildContext(context).ToDynamic();

        foreach (KeyValuePair<string, object> keyValuePair in parameters)
        {
            if (keyValuePair.Value.IsScript())
            {
                results[keyValuePair.Key] =
                    (await InternalEvaluateAsync(keyValuePair.Value, dynamicContext, cancellationToken)).ToString();
                continue;
            }

            results[keyValuePair.Key] = keyValuePair.Value.ToString();
        }

        return results;
    }

    public async Task<object> EvaluateAsync(object expression, GlobalContext context,
        CancellationToken cancellationToken)
    {
        dynamic dynamicContext = BuildContext(context).ToDynamic();

        return await InternalEvaluateAsync(expression, dynamicContext, cancellationToken);
    }

    #endregion

    #region Private Methods

    private async Task<object> InternalEvaluateAsync(object expression, object context,
        CancellationToken cancellationToken)
    {
        if (!expression.IsScript()) return expression;

        return await _scriptEngine.EvaluateAsync<object>(expression.ToExpression(), context, cancellationToken);
    }

    private GlobalContext BuildContext(GlobalContext context)
    {
        if (context.Parameters == null || !context.Parameters.Any()) return context;

        Dictionary<string, object> evaluatedParameters = new Dictionary<string, object>();

        foreach (KeyValuePair<string, object> keyValuePair in context.Parameters)
            evaluatedParameters[keyValuePair.Key] =
                ObjectExtension.TryConvertToDynamic(keyValuePair.Value, out dynamic res) ? res : keyValuePair.Value;

        return context with {Parameters = evaluatedParameters};
    }

    #endregion
}