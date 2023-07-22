using FluentValidation.TestHelper;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Enums;
using SCM.SmartNotifications.ApplicationCore.Shared.Validators;

namespace UnitTests;

public class ConditionSettingsValidatorTests
{
    [Fact]
    public async Task ValidateWithAllValuesReturnsTrue()
    {
        OperatorConditionSettings conditionSettings = new OperatorConditionSettings()
        {
            Operator = Operator.Equals,
            Source = "B",
            SelectedValues = "C"
        };

        var validator = new OperatorConditionSettingsValidator();

        var result = await validator.TestValidateAsync(conditionSettings);

        result.ShouldNotHaveAnyValidationErrors();
    }
}