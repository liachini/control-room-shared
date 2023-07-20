using FluentValidation;
using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Validators;

internal class SMSChannelValidator : AbstractValidator<SmsChannel>
{
    public SMSChannelValidator()
    {
        Include(new ChannelValidator());
    }
}