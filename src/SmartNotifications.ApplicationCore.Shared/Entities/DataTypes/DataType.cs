using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public abstract record DataType : ITypeProvider
{
    public object DefaultValue { get; set; }

    public List<object> AllowedValues { get; set; } = new List<object>();

    //Se ValuesSource è uguale a None, recuperi i valori dalla lista AllowedValues
    public ValuesSource ValuesSource { get; set; } = ValuesSource.None;

    public abstract string _Type { get; }
}