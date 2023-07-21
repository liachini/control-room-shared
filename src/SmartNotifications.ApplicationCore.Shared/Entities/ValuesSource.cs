using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

[JsonConverter(typeof(StringEnumConverter))]
public enum ValuesSource
{
    None,
    Country
}