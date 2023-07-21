using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

internal class NotificationDataValidator : AbstractValidator<NotificationData>
{
    public NotificationDataValidator()
    {
        RuleFor(data => data.ActionGroup).SetValidator(new ActionGroupSettingsValidator());
    }
}