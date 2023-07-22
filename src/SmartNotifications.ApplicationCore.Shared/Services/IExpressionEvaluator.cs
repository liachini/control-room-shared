﻿namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public interface IExpressionEvaluator
{
    Task<Dictionary<string, object>> EvaluateAsync(Dictionary<string, object> parameters, object context,
        CancellationToken cancellationToken);

    Task<object> EvaluateAsync(string expression, object context, CancellationToken cancellationToken);
}