using NCrontab;
using SCM.SmartNotifications.ApplicationCore.Shared.Converters;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record QueryNotificationData : NotificationData
{
    /// <summary>
    /// Kusto query
    /// </summary>
    public string Query { get; set; }

    /// <summary>
    /// Select how far back to look each time the data is checked. (minutes)
    /// </summary>
    public int LoopbackPeriod { get; set; }

    /// <summary>
    /// Select how often the alert rule checks if the condition is met. (cron expression)
    /// </summary>
    [JsonConverter(typeof(CrontabJsonConverter))]
    public CrontabSchedule CheckEvery { get; set; }


    public override string _Type => nameof(QueryNotificationData);
}