namespace SCM.SmartNotifications.Shared.Entities.Channels;

public sealed record EmailChannel : IChannel
{
    public string TemplateName { get; set; }
    public string _Type => nameof(EmailChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}