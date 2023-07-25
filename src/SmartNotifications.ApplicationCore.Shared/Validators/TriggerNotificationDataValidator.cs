using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class TriggerNotificationDataValidator : AbstractValidator<TriggerNotificationData>
{
    public TriggerNotificationDataValidator()
    {
        Include(new NotificationDataValidator());
        RuleFor(data => data.CheckSettings).NotEmpty();
        RuleFor(data => data.CheckSettings).SetValidator(new CheckSettingsValidator());


        RuleForEach(model => model.Conditions).SetInheritanceValidator(validator =>
        {
            validator.Add(new OperatorConditionSettingsValidator());
            validator.Add(new OperatorConditionSettingsValidator());
        });
    }
}