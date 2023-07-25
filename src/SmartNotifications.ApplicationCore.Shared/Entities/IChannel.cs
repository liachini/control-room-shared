namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public interface IChannel : ITypeProvider
{
    object Enabled { get; set; }
}