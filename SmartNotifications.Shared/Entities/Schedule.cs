using NCrontab;
using SCM.SmartNotifications.Shared.Converters;

namespace SCM.SmartNotifications.Shared.Entities;

public sealed record Schedule
{
    public string Frequency { get; set; }

    [JsonConverter(typeof(CrontabJsonConverter))]
    public CrontabSchedule CronSchedule { get; set; }

}