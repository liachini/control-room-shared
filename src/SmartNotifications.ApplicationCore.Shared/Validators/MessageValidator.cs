using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class MessageValidator : AbstractValidator<Message>
{
    public MessageValidator()
    {
        RuleFor(message => message.Body).NotEmpty();
        RuleFor(message => message.Title).NotEmpty();
    }
}