using System.Globalization;
using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record User : ITypeProvider
{
    public string Id { get; set; }
    public string ExternalId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public CultureInfo Language { get; set; }
    public bool IsActive { get; set; }

    #region ITypeProvider

    public string _Type => nameof(User);

    #endregion
}