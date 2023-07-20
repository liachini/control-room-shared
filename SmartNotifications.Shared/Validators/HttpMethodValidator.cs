using FluentValidation;
using FluentValidation.Validators;

namespace SCM.SmartNotifications.Shared.Validators;

public class HttpMethodValidator<T> : PropertyValidator<T, string>
{
    public override string Name => "HttpMethodValidator";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (HttpMethod.Get.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Put.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Post.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Delete.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Head.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Options.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Trace.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        if (HttpMethod.Patch.Method.Equals(value, StringComparison.InvariantCultureIgnoreCase)) return true;

        return false;
    }


    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "'{PropertyName}' must be valid uri.";
    }
}