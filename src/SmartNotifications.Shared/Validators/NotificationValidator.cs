using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class NotificationValidator : AbstractValidator<Notification>
{
    public NotificationValidator()
    {
        RuleFor(notification => notification.Id).NotEmpty();

        RuleFor(notification => notification.Scope).NotEmpty().SetValidator(new ScopeSettingsValidator());

        RuleFor(model => model.Data).SetInheritanceValidator(validator =>
        {
            validator.Add(new ReportNotificationDataValidator());
            validator.Add(new QueryNotificationDataValidator());
            validator.Add(new TriggerNotificationDataValidator());
        });
    }
}