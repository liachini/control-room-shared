namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record ObjectDataType : DataType
{
    public override string _Type { get; } = nameof(ObjectDataType);
}