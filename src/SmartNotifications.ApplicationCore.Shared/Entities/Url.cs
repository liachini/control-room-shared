using SCM.SmartNotifications.ApplicationCore.Shared.Services;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record Url
{
    public Url(Uri address, HttpMethod httpMethod, Dictionary<string, object> Parameters = null)
    {
        Address = address;
        HttpMethod = httpMethod;
        this.Parameters = Parameters ?? new Dictionary<string, object>();
    }

    public Dictionary<string, object> Parameters { get; init; }
    public Dictionary<string, object> Headers { get; init; } = new Dictionary<string, object>();

    public Uri Address { get; set; }
    public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;

}