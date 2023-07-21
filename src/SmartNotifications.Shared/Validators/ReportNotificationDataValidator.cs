﻿using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

internal class ReportNotificationDataValidator : AbstractValidator<ReportNotificationData>
{
    public ReportNotificationDataValidator()
    {
        Include(new NotificationDataValidator());

        RuleFor(data => data.Name).NotEmpty();

        RuleFor(data => data.ApiUrl).NotEmpty();

        RuleFor(data => data.SelectedSchedule).NotEmpty();

        RuleFor(data => data.ApiUrl).SetValidator(new UrlValidator());

        RuleFor(data => data.SelectedSchedule).SetValidator(new ScheduleValidator());
    }
}