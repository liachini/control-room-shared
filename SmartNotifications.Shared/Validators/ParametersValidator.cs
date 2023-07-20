using FluentValidation;

namespace SCM.SmartNotifications.Shared.Validators;

public class ParametersValidator : AbstractValidator<Dictionary<string,object>>
{
    public ParametersValidator()
    {
        RuleForEach(settings => settings.Keys).NotEmpty();
        RuleForEach(settings => settings.Values).NotEmpty();
    }
}