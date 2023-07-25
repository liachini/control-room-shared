namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public record CheckSettings : ITypeProvider
{
    public string CheckKey { get; init; }


    /// <summary>
    ///     The maximum number of times an alert is reported. If the number of times an alert is reported exceeds the specified
    ///     threshold, the alert is no longer reported.
    /// </summary>
    public int MaximumAlerts { get; set; }

    /// <summary>
    ///     The minimum interval at which an alert is reported (seconds)
    /// </summary>
    public int MinimumAlertInterval { get; set; }

    /// <summary>
    /// Number of subsequent checks that must be successful
    /// </summary>
    public int Count { get; init; }

    /// <summary>
    /// Duration of the event before it is considered successful
    /// </summary>
    public long Duration { get; init; }

    public string _Type { get; } = nameof(CheckSettings);
}