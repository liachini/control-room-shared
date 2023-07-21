namespace SCM.SmartNotifications.Shared.Entities;

public record CheckSettings : ITypeProvider
{
    public int Count { get; init; }
    public long Duration { get; init; }

    public string _Type { get; } = nameof(CheckSettings);
}