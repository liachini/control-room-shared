
namespace SCM.SmartNotifications.Shared.Entities;

public sealed record ScopeSettings
{
    public ScopeSource Source { get; set; }

    public Dictionary<string, object> Parameters { get; set; }

    public List<object> SelectedScopes { get; set; }
}