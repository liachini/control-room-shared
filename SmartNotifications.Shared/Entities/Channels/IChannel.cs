namespace SCM.SmartNotifications.Shared.Entities.Channels;

public interface IChannel : ITypeProvider
{
    public LocalizedMessage LocalizedMessage { get; set; }
}

