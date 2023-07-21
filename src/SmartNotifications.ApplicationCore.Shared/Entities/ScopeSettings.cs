
using SCM.SmartNotifications.ApplicationCore.Shared.Enums;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record ScopeSettings
{
    public ScopeSource Source { get; set; }

    public Dictionary<string, object> Parameters { get; set; }

    public List<object> SelectedScopes { get; set; }
}