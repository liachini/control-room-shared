using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities.Channels;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class EmailChannelValidator : AbstractValidator<EmailChannel>
{
    public EmailChannelValidator()
    {
        Include(new ChannelValidator());
    }
}