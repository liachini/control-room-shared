namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record TriggerNotificationData : NotificationData
{



    public CheckSettings CheckSettings { get; init; } = new CheckSettings();

    public List<IConditionSettings> Conditions { get; init; }
    public override string _Type => nameof(TriggerNotificationData);
}