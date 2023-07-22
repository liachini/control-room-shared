using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public interface IChannel : ITypeProvider
{
    public LocalizedMessage LocalizedMessage { get; set; }
}