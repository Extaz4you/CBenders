using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CBenders.Web;

public static class Details
{
    public static string MenuApiBase { get; set; }
    public enum ApiType { GET, POST, PUT, DELETE }
}
