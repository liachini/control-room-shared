﻿namespace SCM.SmartNotifications.Shared.Entities;

public sealed record Notification : ITypeProvider, ISupportsDelete
{
    public string Name { get; set; }
    public ScopeSettings Scope { get; set; }

    public NotificationData Data { get; set; }

    public string Version { get; set; }

    public bool Enabled { get; set; }

    public string Id { get; set; }

    public long TTL { get; set; }

    public bool IsDeleted()
    {
        return TTL > 0;
    }

    public string _Type { get; } = nameof(Notification);
}