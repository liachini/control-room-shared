using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class ActionGroupSettingsValidator : AbstractValidator<ActionGroupSettings>
{
    public ActionGroupSettingsValidator()
    {
        RuleFor(setttings => setttings.Channels).NotEmpty();
        RuleForEach(settings => settings.Channels).SetInheritanceValidator(validator =>
        {
            validator.Add(new EmailChannelValidator());
            validator.Add(new SMSChannelValidator());
            validator.Add(new PushChannelValidator());
        });
        RuleFor(settings => settings.Recipients).SetValidator(new RecipientsSettingsValidator());
    }
}