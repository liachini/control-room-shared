﻿namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities.DataTypes;

public sealed record ArrayDataType : DataType
{
    public override string _Type => nameof(ArrayDataType);
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
}