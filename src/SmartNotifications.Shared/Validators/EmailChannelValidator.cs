using FluentValidation;
using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Validators;

internal class EmailChannelValidator : AbstractValidator<EmailChannel>
{
    public EmailChannelValidator()
    {
        Include(new ChannelValidator());
    }
}