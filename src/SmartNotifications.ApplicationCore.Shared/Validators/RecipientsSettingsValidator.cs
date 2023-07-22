using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class RecipientsSettingsValidator : AbstractValidator<RecipientsSettings>
{
    public RecipientsSettingsValidator()
    {
        RuleForEach(settings => settings.Users).SetValidator(new UserValidator());
        RuleFor(settings => settings.GroupFilters).SetValidator(new ParametersValidator());
    }
}