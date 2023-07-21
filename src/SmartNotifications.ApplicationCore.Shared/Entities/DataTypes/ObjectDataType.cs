namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities.DataTypes;

public sealed record ObjectDataType : DataType
{
    public override string _Type { get; } = nameof(ObjectDataType);
}