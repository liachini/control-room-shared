namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record NotificationInstance : BaseEntity
{
    public string TemplateRefId { get; set; }

    public Dictionary<string, object> Parameters { get; set; }

    public Notification Notification { get; set; }

    public override string _Type { get; } = nameof(NotificationInstance);
}