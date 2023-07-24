namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public abstract record BaseEntity : ITypeProvider, ISupportsDelete
{
    [JsonProperty("id")] public string Id { get; init; } = Guid.NewGuid().ToString();

    public DateTimeOffset CreationDate { get; init; } = DateTimeOffset.UtcNow;

    public long TTL { get; init; }

    public bool IsDeleted()
    {
        return TTL > 0;
    }

    [JsonProperty("_type")] public abstract string _Type { get; }
}