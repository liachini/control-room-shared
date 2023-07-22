using Castle.Core.Logging;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Logging;
using NSubstitute;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Services;
using SCM.SmartNotifications.ApplicationCore.Shared.Validators;

namespace UnitTests;

public class UserValidatorTests
{
    [Fact]
    public void ValidateWhenPhoneNumberIsNotANumberReturnsFalse()
    {
        User user = new User
        {
            CountryCode = "ITA",
            PhoneNumber = "prova"
        };
        UserValidator validator = new UserValidator();

        TestValidationResult<User>? result = validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(user1 => user1.PhoneNumber);
    }

    [Fact]
    public void ValidateWhenPhoneNumberIsValidReturnsTrue()
    {
        User user = new User
        {
            CountryCode = "ITA",
            PhoneNumber = "54646664"
        };
        UserValidator validator = new UserValidator();

        TestValidationResult<User>? result = validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(user1 => user1.PhoneNumber);
    }

}