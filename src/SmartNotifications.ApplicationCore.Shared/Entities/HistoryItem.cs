using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public record HistoryItem : BaseEntity
{
    public string UserId { get; set; }
    public string Content { get; set; }

    public string Channel { get; set; }

    public State State { get; set; }
    public override string _Type { get; } = nameof(HistoryItem);
}

[JsonConverter(typeof(StringEnumConverter))]
public enum State
{
    New,
    Old,
    Read
}