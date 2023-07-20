using FluentValidation;
using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Validators;

internal class ChannelValidator : AbstractValidator<IChannel>
{
    public ChannelValidator()
    {
        RuleFor(channel => channel.LocalizedMessage).SetValidator(new LocalizedMessageValidator());
    }
}