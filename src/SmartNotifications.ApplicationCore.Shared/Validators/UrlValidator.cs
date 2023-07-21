using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class UrlValidator : AbstractValidator<Url>
{
    public UrlValidator()
    {
        RuleFor(url => url.Address).NotEmpty();
        RuleFor(url => url.HttpMethod).NotEmpty();
    }
}