using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class LocalizedMessageValidator : AbstractValidator<LocalizedMessage>
{
    public LocalizedMessageValidator()
    {
        RuleFor(message => message.DefaultMessage).NotEmpty().SetValidator(new MessageValidator());

        RuleForEach(message => message.Translations.Values).SetValidator(new MessageValidator());
    }
}