using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class NotificationTemplateValidator : AbstractValidator<NotificationTemplate>
{
    public NotificationTemplateValidator()
    {
        RuleFor(template => template.Notification).SetValidator(new NotificationValidator());
    }

}
public class NotificationValidator : AbstractValidator<Notification>
{
    public NotificationValidator()
    {
        RuleFor(notification => notification.Scope).NotEmpty().SetValidator(new ScopeSettingsValidator());

        RuleFor(model => model.Data).SetInheritanceValidator(validator =>
        {
            validator.Add(new ReportNotificationDataValidator());
            validator.Add(new QueryNotificationDataValidator());
            validator.Add(new TriggerNotificationDataValidator());
        });
    }
}