namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record StringDataType : DataType
{
    public override string _Type => nameof(StringDataType);
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
}