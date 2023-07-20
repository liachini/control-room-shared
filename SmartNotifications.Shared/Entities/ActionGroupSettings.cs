﻿using SCM.SmartNotifications.Shared.Entities.Channels;

namespace SCM.SmartNotifications.Shared.Entities;

public sealed record ActionGroupSettings: ITypeProvider
{
    public IList<IChannel> Channels { get; set; }

    public RecipientsSettings Recipients { get; set; }
    public string _Type { get; } = nameof(ActionGroupSettings);
}