using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class TriggerNotificationDataValidator : AbstractValidator<TriggerNotificationData>
{
    public TriggerNotificationDataValidator()
    {
        RuleFor(data => data.MonitoredItem).NotEmpty();
        RuleFor(data => data.CheckSettings).NotEmpty();
    }
}