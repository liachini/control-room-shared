namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record WebhookChannel : IChannel
{
    public Url Endpoint { get; set; }
    public string _Type => nameof(WebhookChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}