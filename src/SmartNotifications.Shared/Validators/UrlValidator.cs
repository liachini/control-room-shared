using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

public class UrlValidator : AbstractValidator<Url>
{
    public UrlValidator()
    {
        RuleFor(url => url.Address).NotEmpty();
        RuleFor(url => url.HttpMethod).NotEmpty();
    }
}