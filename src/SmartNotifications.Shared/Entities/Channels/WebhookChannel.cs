namespace SCM.SmartNotifications.Shared.Entities.Channels;

public sealed record WebhookChannel : IChannel
{
    public Url Endpoint { get; set; }
    public string _Type => nameof(WebhookChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}