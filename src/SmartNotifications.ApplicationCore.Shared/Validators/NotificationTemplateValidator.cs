using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class NotificationTemplateValidator : AbstractValidator<NotificationTemplate>
{
    public NotificationTemplateValidator()
    {
        RuleFor(template => template.Notification).SetValidator(new NotificationValidator());
    }
}

public class NotificationInstanceValidator : AbstractValidator<NotificationInstance>
{
    public NotificationInstanceValidator()
    {
        RuleFor(template => template.Notification).SetValidator(new NotificationValidator());
        RuleFor(template => template.Parameters).NotEmpty();

    }
}