namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities.DataTypes;

public sealed record DateTimeDataType : DataType
{
    public override string _Type => nameof(DateTimeDataType);
    public DateTime? MinValue { get; set; }
    public DateTime? MaxValue { get; set; }
}