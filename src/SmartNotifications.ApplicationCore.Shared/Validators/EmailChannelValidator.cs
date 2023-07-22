using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class EmailChannelValidator : AbstractValidator<EmailChannel>
{
    public EmailChannelValidator()
    {
        Include(new ChannelValidator());
    }
}