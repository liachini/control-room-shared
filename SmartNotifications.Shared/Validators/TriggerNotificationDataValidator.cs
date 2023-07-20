using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

internal class TriggerNotificationDataValidator : AbstractValidator<TriggerNotificationData>
{
    public TriggerNotificationDataValidator()
    {
        RuleFor(data => data.MonitoredItem).NotEmpty();
        RuleFor(data => data.CheckSettings).NotEmpty();
    }
}