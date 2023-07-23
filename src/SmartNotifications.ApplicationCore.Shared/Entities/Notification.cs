using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record Notification : ITypeProvider, ISupportsDelete
{
    public string Key { get; init; }

    public ScopeSettings Scope { get; init; }

    public NotificationData Data { get; init; }

    public string Version { get; init; }

    public bool Enabled { get; init; }

    public long TTL { get; init; }

    public bool IsDeleted()
    {
        return TTL > 0;
    }

    public string _Type { get; } = nameof(Notification);
}