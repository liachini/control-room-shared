using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Interfaces;

public interface IChannel : ITypeProvider
{
    public LocalizedMessage LocalizedMessage { get; set; }
}

