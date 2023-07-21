namespace SCM.SmartNotifications.Shared.Entities;

public abstract record BaseEntity : ITypeProvider, ISupportsDelete
{
    [JsonProperty("id")] public string Id { get; set; } = Guid.NewGuid().ToString();

    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;

    public long TTL { get; set; }

    public bool IsDeleted()
    {
        return TTL > 0;
    }

    [JsonProperty("_type")] public abstract string _Type { get; }
}