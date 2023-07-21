namespace SCM.SmartNotifications.Shared.Entities;

public sealed record NotificationTemplate : BaseEntity
{
    public Dictionary<string, ParameterTemplate> Parameters { get; set; }

    public Notification Notification { get; set; }
    public override string _Type { get; } = nameof(NotificationTemplate);
}