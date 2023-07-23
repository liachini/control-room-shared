namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record NotificationInstance : BaseEntity
{
    public string TemplateRefId { get; init; }

    public Dictionary<string, object> Parameters { get; init; }

    public Notification Notification { get; init; }

    public override string _Type { get; } = nameof(NotificationInstance);
}