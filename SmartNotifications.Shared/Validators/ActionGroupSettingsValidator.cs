using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

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
        RuleFor(settings => settings.Recipients).NotEmpty().SetValidator(new RecipientsSettingsValidator());
    }
}