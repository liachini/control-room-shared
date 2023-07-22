using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class TriggerNotificationDataValidator : AbstractValidator<TriggerNotificationData>
{
    public TriggerNotificationDataValidator()
    {
        Include(new NotificationDataValidator());
        RuleFor(data => data.CheckSettings).NotEmpty();
    }
}