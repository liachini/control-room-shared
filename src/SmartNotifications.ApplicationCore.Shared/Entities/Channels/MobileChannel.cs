﻿namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record MobileChannel : IChannel
{
    public string _Type => nameof(MobileChannel);
    public object Enabled { get; set; }
}