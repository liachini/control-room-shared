using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

public sealed record MobileChannel : IChannel
{
    public string _Type => nameof(MobileChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}