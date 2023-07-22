using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public interface IConditionSettings : ITypeProvider
{
    string Name { get; set; }
    string Source { get; set; }
}