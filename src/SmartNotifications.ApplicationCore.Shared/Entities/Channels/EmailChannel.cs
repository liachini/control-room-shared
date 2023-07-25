namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record EmailChannel : IChannel
{
    public string TemplateName { get; set; }
    public string _Type => nameof(EmailChannel);
    public object Enabled { get; set; }
    public LocalizedMessage LocalizedMessage { get; set; }
}