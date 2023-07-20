﻿namespace SCM.SmartNotifications.Shared.Entities;

public sealed record ReportNotificationData : NotificationData
{
    public string Name { get; set; }

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