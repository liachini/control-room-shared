namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public record CheckSettings : ITypeProvider
{
    public string CounterKey { get; init; }

    public int Count { get; init; }
    public long Duration { get; init; }

    public string _Type { get; } = nameof(CheckSettings);
}