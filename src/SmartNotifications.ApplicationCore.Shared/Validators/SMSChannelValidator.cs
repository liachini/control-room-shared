using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class SMSChannelValidator : AbstractValidator<SmsChannel>
{
    public SMSChannelValidator()
    {
        Include(new ChannelValidator());
        RuleFor(channel => channel.LocalizedMessage).SetValidator(new LocalizedMessageValidator());
    }
}