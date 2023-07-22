using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class OperatorConditionSettingsValidator : AbstractValidator<OperatorConditionSettings>
{
    public OperatorConditionSettingsValidator()
    {
        RuleFor(settings => settings.Operator).NotNull();
        RuleFor(settings => settings.SelectedValues).NotEmpty();
        RuleFor(settings => settings.Source).NotEmpty();
    }
}