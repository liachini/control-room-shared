
namespace SCM.SmartNotifications.Shared.Interfaces;

public interface ISupportsDelete
{
    public long TTL { get; set; }

    bool IsDeleted();
}