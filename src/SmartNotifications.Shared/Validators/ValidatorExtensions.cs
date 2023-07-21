using FluentValidation;

namespace SCM.SmartNotifications.Shared.Validators;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> Uri<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new UriValidator<T>());
    }
}