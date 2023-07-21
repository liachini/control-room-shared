using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class ScopeSettingsValidator : AbstractValidator<ScopeSettings>
{
    public ScopeSettingsValidator()
    {
        RuleFor(settings => settings.Source).NotNull();
        RuleFor(settings => settings.Parameters).SetValidator(new ParametersValidator());
    }
}