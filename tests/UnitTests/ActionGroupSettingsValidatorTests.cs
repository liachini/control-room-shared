using AutoFixture;
using FluentValidation.TestHelper;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Validators;

namespace UnitTests;

public class ActionGroupSettingsValidatorTests
{
    [Fact]
    public async Task ValidateWhenEmptyChannelReturnsFalse()
    {
        Fixture fixture = new Fixture();

        ActionGroupSettings actionGroupSettings = new ActionGroupSettings
        {
            Recipients = fixture.Create<RecipientsSettings>(),
            Channels = new List<IChannel>()
        };

        ActionGroupSettingsValidator validator = new ActionGroupSettingsValidator();

        TestValidationResult<ActionGroupSettings>? validationResult =
            await validator.TestValidateAsync(actionGroupSettings);
        validationResult.ShouldHaveValidationErrorFor(settings => settings.Channels);
    }


    [Fact]
    public async Task ValidateWhenNullChannelReturnsFalse()
    {
        Fixture fixture = new Fixture();

        ActionGroupSettings actionGroupSettings = new ActionGroupSettings
        {
            Recipients = fixture.Create<RecipientsSettings>(),
            Channels = null
        };

        ActionGroupSettingsValidator validator = new ActionGroupSettingsValidator();

        TestValidationResult<ActionGroupSettings>? validationResult =
            await validator.TestValidateAsync(actionGroupSettings);
        validationResult.ShouldHaveValidationErrorFor(settings => settings.Channels);
    }

    [Fact]
    public async Task ValidateWhenRecpipientsIsNullReturnsFalse()
    {
        Fixture fixture = new Fixture();

        ActionGroupSettings actionGroupSettings = new ActionGroupSettings
        {
            Channels = fixture.Create<List<EmailChannel>>().Cast<IChannel>().ToList(),
            Recipients = null
        };

        ActionGroupSettingsValidator validator = new ActionGroupSettingsValidator();

        TestValidationResult<ActionGroupSettings>? validationResult =
            await validator.TestValidateAsync(actionGroupSettings);
        validationResult.ShouldHaveAnyValidationError();
    }
}