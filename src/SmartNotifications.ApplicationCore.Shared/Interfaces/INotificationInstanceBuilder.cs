namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface INotificationInstanceBuilder
{
    Task<NotificationInstance> BuildAsync(NotificationTemplate template, Dictionary<string, object> parameters);
}