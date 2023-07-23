using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public interface IChannel : ITypeProvider
{
    bool Enabled { get; set; }
    LocalizedMessage LocalizedMessage { get; set; }
}