using SCM.SmartNotifications.Shared.Entities.DataTypes;

namespace SCM.SmartNotifications.Shared.Entities;

public sealed record ParameterTemplate
{
    public string Name { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public string Hint { get; set; }
    public DataType DataType { get; set; }
    public IList<Operator> AllowedOperators { get; set; } = new List<Operator>();
    public object DefaultValue { get; set; }
    public bool Required { get; set; }
    public bool ReadOnly { get; set; }
}