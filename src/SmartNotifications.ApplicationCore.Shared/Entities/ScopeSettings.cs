using SCM.SmartNotifications.ApplicationCore.Shared.Enums;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record ScopeSettings
{
    public ScopeSource Source { get; init; } = ScopeSource.None;

    public Dictionary<string, object> Parameters { get; init; }

    public List<object> SelectedScopes { get; init; }
}