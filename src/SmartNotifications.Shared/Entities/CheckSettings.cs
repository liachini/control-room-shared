using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public record CheckSettings : ITypeProvider
{
    public int Count { get; init; }
    public long Duration { get; init; }

    public string _Type { get; } = nameof(CheckSettings);
}