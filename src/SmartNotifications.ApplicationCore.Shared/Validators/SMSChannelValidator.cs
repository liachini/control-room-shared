using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class SMSChannelValidator : AbstractValidator<SmsChannel>
{
    public SMSChannelValidator()
    {
        Include(new ChannelValidator());
    }
}