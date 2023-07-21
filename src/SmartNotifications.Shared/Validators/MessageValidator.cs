using FluentValidation;
using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Validators;

internal class MessageValidator : AbstractValidator<Message>
{
    public MessageValidator()
    {
        RuleFor(message => message.Body).NotEmpty();
        RuleFor(message => message.Title).NotEmpty();
    }
}