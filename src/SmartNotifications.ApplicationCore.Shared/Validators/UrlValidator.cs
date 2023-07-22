using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class UrlValidator : AbstractValidator<Url>
{
    public UrlValidator()
    {
        RuleFor(url => url.Address).NotEmpty();
        RuleFor(url => url.HttpMethod).NotEmpty();
    }
}