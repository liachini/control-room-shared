using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class PushChannelValidator : AbstractValidator<PushChannel>
{
    public PushChannelValidator()
    {
        Include(new ChannelValidator());
    }
}