using FluentValidation;
using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Validators;

internal class PushChannelValidator : AbstractValidator<PushChannel>
{
    public PushChannelValidator()
    {
        Include(new ChannelValidator());
    }
}