namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public interface IChannel : ITypeProvider
{
    bool Enabled { get; set; }
}