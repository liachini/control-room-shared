namespace SCM.SmartNotifications.Shared.Entities.Channels;

public sealed record SmsChannel : IChannel
{
    public string _Type => nameof(SmsChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}