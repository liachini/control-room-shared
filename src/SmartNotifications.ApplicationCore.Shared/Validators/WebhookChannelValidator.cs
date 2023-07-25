using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class WebhookChannelValidator : AbstractValidator<WebhookChannel>
{
    public WebhookChannelValidator()
    {
        Include(new ChannelValidator());
        RuleFor(channel => channel.Endpoint).SetValidator(new UrlValidator());
    }
}