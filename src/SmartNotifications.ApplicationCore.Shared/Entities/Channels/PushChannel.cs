﻿namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record PushChannel : IChannel
{
    public string _Type => nameof(PushChannel);
    public object Enabled { get; set; }
    public LocalizedMessage LocalizedMessage { get; set; }
}