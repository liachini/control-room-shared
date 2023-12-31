﻿using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public class NotificationBuilderInstance : INotificationInstanceBuilder
{
    private readonly IExpressionEvaluator _expressionEvaluator;

    public NotificationBuilderInstance(IExpressionEvaluator expressionEvaluator)
    {
        _expressionEvaluator = expressionEvaluator;
    }

    public async Task<NotificationInstance> BuildAsync(NotificationTemplate template,
        Dictionary<string, object> parameters)
    {
        NotificationInstance notificationInstance = new NotificationInstance
        {
            Parameters = parameters,
            TemplateRefId = template.Id,
            Notification = await BuildNotification(template.Notification, parameters)
        };

        return notificationInstance;
    }

    private async Task<Notification> BuildNotification(Notification notification, Dictionary<string, object> parameters)
    {
        return notification with {Route = await EvaluateKeyAsync(notification.Route, parameters)};
    }

    private async Task<string> EvaluateKeyAsync(string key, Dictionary<string, object> parameters)
    {
        GlobalContext globalContext = new GlobalContext("", null, null)
        {
            Parameters = parameters
        };

        return (string) await _expressionEvaluator.EvaluateAsync(key, globalContext, CancellationToken.None);
    }
}