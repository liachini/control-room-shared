namespace SCM.SmartNotifications.Shared.Entities.DataTypes;

public sealed record StringDataType : DataType
{
    public override string _Type => nameof(StringDataType);
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
}