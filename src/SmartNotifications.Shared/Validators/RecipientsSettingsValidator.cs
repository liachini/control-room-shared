using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class RecipientsSettingsValidator : AbstractValidator<RecipientsSettings>
{
    public RecipientsSettingsValidator()
    {
        RuleForEach(settings => settings.Users).SetValidator(new UserValidator());
        RuleFor(settings => settings.GroupFilters).SetValidator(new ParametersValidator());
    }
}