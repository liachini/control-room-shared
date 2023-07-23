namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record SmsChannel : IChannel
{
    public string _Type => nameof(SmsChannel);
    public bool Enabled { get; set; }
    public LocalizedMessage LocalizedMessage { get; set; }
}