using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class PushChannelValidator : AbstractValidator<PushChannel>
{
    public PushChannelValidator()
    {
        Include(new ChannelValidator());
        RuleFor(channel => channel.LocalizedMessage).SetValidator(new LocalizedMessageValidator());

    }
}