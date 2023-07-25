using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class EmailChannelValidator : AbstractValidator<EmailChannel>
{
    public EmailChannelValidator()
    {
        Include(new ChannelValidator());
        RuleFor(channel => channel.LocalizedMessage).SetValidator(new LocalizedMessageValidator());

    }
}