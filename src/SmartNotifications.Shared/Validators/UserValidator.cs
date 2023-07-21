using FluentValidation;
using PhoneNumbers;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.FirstName).NotEmpty();
        RuleFor(user => user.LastName).NotEmpty();
        RuleFor(user => user.Language).NotEmpty();
        RuleFor(user => user.UserName).NotEmpty();
        RuleFor(user => user.Email).NotEmpty().EmailAddress();
        RuleFor(user => user).Must(user => ValidNumber(user.CountryCode, user.PhoneNumber)).When(user =>
            !string.IsNullOrWhiteSpace(user.PhoneNumber) && !string.IsNullOrWhiteSpace(user.CountryCode)).WithMessage("Not valid phone number").OverridePropertyName(nameof(User.PhoneNumber));
    }

    private static bool ValidNumber(string countryCode, string tel)
    {
        try
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber phoneNumber = phoneNumberUtil.Parse(tel, countryCode);
            return phoneNumberUtil.IsValidNumber(phoneNumber);
        }
        catch
        {
            return false;
        }
    }
}