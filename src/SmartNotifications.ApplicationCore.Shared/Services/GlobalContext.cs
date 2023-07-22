namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public record GlobalContext
{
    public GlobalContext(string notificationId, IEnumerable<object> scopes, dynamic data)
    {
        NotificationId = notificationId;
        Scopes = scopes;
        Data = data;
    }

    public string NotificationId { get; init; }
    public IEnumerable<object> Scopes { get; init; } = new List<object>();
    public object CurrentScope { get; set; }
    public dynamic Data { get; set; }
    public Dictionary<string, object> Variables { get; init; } = new Dictionary<string, object>();
    public Dictionary<string, object> Parameters { get; init; } = new Dictionary<string, object>();
    public User CurrentUser { get; init; }
    public IEnumerable<User> Users { get; init; } = new List<User>();
}