namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface ISupportsDelete
{
    public long TTL { get; init; }

    bool IsDeleted();
}