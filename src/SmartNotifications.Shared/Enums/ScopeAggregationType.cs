using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.Shared.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ScopeAggregationType
{
    None,
    Group
}