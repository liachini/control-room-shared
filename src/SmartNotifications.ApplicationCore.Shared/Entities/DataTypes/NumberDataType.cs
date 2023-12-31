﻿namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record NumberDataType : DataType
{
    public override string _Type => nameof(NumberDataType);
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }
}