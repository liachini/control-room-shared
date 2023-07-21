using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

public sealed record PushChannel : IChannel
{
    public string _Type => nameof(PushChannel);
    public LocalizedMessage LocalizedMessage { get; set; }
}