namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record TriggerNotificationData : NotificationData
{
    /// <summary>
    ///     The maximum number of times an alert is reported. If the number of times an alert is reported exceeds the specified
    ///     threshold, the alert is no longer reported.
    /// </summary>
    public int MaximumAlerts { get; set; }

    /// <summary>
    ///     The minimum interval at which an alert is reported (seconds)
    /// </summary>
    public int MinimumAlertInterval { get; set; }

    public CheckSettings CheckSettings { get; set; } = new CheckSettings();

    public List<IConditionSettings> Conditions { get; set; }
    public override string _Type => nameof(TriggerNotificationData);
}