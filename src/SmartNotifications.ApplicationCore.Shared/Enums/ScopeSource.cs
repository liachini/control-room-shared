using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ScopeSource
{
    None,
    Machines,
    OrgByCountry
}