using FluentValidation;
using FluentValidation.Validators;

namespace SCM.SmartNotifications.Shared.Validators;

public class UriValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "UriValidator";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute);
    }


    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "'{PropertyName}' must be valid uri.";
    }
}