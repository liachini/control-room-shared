﻿using Newtonsoft.Json.Converters;

namespace SCM.SmartNotifications.Shared.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Operator
{
    Equals,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    In
}