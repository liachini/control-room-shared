using NCrontab;
using SCM.SmartNotifications.ApplicationCore.Shared.Converters;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record Schedule
{
    public string Frequency { get; set; }

    [JsonConverter(typeof(CrontabJsonConverter))]
    public CrontabSchedule CronSchedule { get; set; }

}