namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record ReportNotificationData : NotificationData
{
    /// <summary>
    ///     Remote url to invoke to retrieve data
    /// </summary>
    public Url ApiUrl { get; set; }

    /// <summary>
    ///     Select how often the report is to be sent
    /// </summary>
    public Schedule SelectedSchedule { get; set; }


    public override string _Type => nameof(ReportNotificationData);
}