﻿using System.Globalization;
using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record LocalizedMessage : ITypeProvider
{
    public Message DefaultMessage { get; set; }

    public Dictionary<CultureInfo, Message> Translations { get; set; }
    public string _Type => nameof(LocalizedMessage);
}