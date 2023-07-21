﻿using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class NotificationDataValidator : AbstractValidator<NotificationData>
{
    public NotificationDataValidator()
    {
        RuleFor(data => data.ActionGroup).SetValidator(new ActionGroupSettingsValidator());
    }
}