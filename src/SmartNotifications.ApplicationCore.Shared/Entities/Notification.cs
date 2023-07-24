namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record Notification : ITypeProvider
{
    public string Key { get; init; }

    public ScopeSettings Scope { get; init; } = new ScopeSettings();

    public NotificationData Data { get; init; }

    public string Version { get; init; }

    public string _Type { get; } = nameof(Notification);
}