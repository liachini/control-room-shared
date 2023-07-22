﻿using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class ChannelValidator : AbstractValidator<IChannel>
{
    public ChannelValidator()
    {
        RuleFor(channel => channel.LocalizedMessage).SetValidator(new LocalizedMessageValidator());
    }
}