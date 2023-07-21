using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

internal class ScopeSettingsValidator : AbstractValidator<ScopeSettings>
{
    public ScopeSettingsValidator()
    {
        RuleFor(settings => settings.Source).NotNull();
        RuleFor(settings => settings.Parameters).SetValidator(new ParametersValidator());
    }
}