namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record NotificationTemplate : BaseEntity
{
    public string Name { get; init; }
    public string Category { get; init; }
    public string Description { get; init; }

    public Dictionary<string, ParameterTemplate> Parameters { get; init; } = new Dictionary<string, ParameterTemplate>();
    public Notification Notification { get; init; }
    public Dictionary<string, string> Tags { get; init; } = new Dictionary<string, string>();
    public override string _Type { get; } = nameof(NotificationTemplate);
}