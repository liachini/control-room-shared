using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record Template : ITypeProvider
{
    public Dictionary<string, ParameterTemplate> ParameterTemplates { get; set; } =
        new Dictionary<string, ParameterTemplate>();

    public string _Type { get; } = nameof(Template);
}