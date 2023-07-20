namespace SCM.SmartNotifications.Shared.Entities;

public sealed record OperatorConditionSettings : IConditionSettings
{
    /// <summary>
    ///     The operator used on the path name and value
    /// </summary>
    public Operator Operator { get; set; }

    /// <summary>
    ///     The dimension values selected
    /// </summary>
    public object SelectedValues { get; set; }

    public string Name { get; set; }

    /// <summary>
    ///     Property to which the condition applies
    /// </summary>
    public string Source { get; set; }

    public string _Type => nameof(OperatorConditionSettings);
}