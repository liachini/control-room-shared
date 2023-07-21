namespace SCM.SmartNotifications.Shared.Entities;

public sealed record Template : ITypeProvider
{
    public string _Type { get; } = nameof(Template);

    public Dictionary<string, ParameterTemplate> ParameterTemplates { get; set; } =
        new Dictionary<string, ParameterTemplate>();
}