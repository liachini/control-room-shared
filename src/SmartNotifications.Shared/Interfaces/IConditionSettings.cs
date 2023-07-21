namespace SCM.SmartNotifications.Shared.Interfaces;

public interface IConditionSettings : ITypeProvider
{
    string Name { get; set; }
    string Source { get; set; }
}