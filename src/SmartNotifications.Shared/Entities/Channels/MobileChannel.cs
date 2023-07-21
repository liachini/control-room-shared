namespace SCM.SmartNotifications.Shared.Entities.Channels;

public sealed record MobileChannel : IChannel
{
    public string _Type => nameof(MobileChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}