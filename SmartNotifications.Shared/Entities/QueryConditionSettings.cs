namespace SCM.SmartNotifications.Shared.Entities;

public sealed record QueryConditionSettings : IConditionSettings
{
    public Dictionary<string, object> Parameters { get; set; }
    public string _Type { get; } = nameof(QueryConditionSettings);
    public string Name { get; set; }
    public string Source { get; set; }
}