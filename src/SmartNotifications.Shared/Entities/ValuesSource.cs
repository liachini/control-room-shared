using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.Shared.Entities;

[JsonConverter(typeof(StringEnumConverter))]
public enum ValuesSource
{
    None,
    Country
}