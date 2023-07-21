using SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface IChannel : ITypeProvider
{
    public LocalizedMessage LocalizedMessage { get; set; }
}

