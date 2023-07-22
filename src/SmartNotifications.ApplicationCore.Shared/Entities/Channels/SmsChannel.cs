using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record SmsChannel : IChannel
{
    public string _Type => nameof(SmsChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}