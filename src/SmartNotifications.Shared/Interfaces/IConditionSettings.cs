namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface IConditionSettings : ITypeProvider
{
    string Name { get; set; }
    string Source { get; set; }
}