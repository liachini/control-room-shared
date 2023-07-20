namespace SCM.SmartNotifications.Shared.Entities;

public interface IConditionSettings : ITypeProvider
{
    string Name { get; set; }
    string Source { get; set; }
}