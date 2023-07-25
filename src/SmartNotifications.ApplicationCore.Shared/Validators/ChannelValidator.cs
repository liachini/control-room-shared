using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class ChannelValidator : AbstractValidator<IChannel>
{
    public ChannelValidator()
    {
    }
}


internal class CheckSettingsValidator : AbstractValidator<CheckSettings>
{
    public CheckSettingsValidator()
    {
    }
}