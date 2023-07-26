namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public record CheckSettings : ITypeProvider
{
    public string CounterKey { get; init; }

    public RateSettings RateLimit { get; set; }
    public RateSettings RateLimitByKey { get; set; }
    
    /// <summary>
    ///     Number of subsequent checks that must be successful
    /// </summary>
    public int HitCount { get; init; }

    /// <summary>
    ///     Duration of the event before it is considered successful
    /// </summary>
    public long Duration { get; init; }

    public string _Type { get; } = nameof(CheckSettings);
}

public record RateSettings
{
    /// <summary>
    ///     The maximum number of times an alert is reported. If the number of times an alert is reported exceeds the specified
    ///     threshold, the alert is no longer reported.
    /// </summary>
    public int MaximumNumberOfCalls { get; init; }

    /// <summary>
    ///     The length in seconds during which the number of notifications cannot exceed the value specified in
    ///     <see cref="MaximumNumberOfCalls" />
    /// </summary>
    public int RenewalPeriod { get; init; }
}