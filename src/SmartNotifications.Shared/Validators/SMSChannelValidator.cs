using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class SMSChannelValidator : AbstractValidator<SmsChannel>
{
    public SMSChannelValidator()
    {
        Include(new ChannelValidator());
    }
}