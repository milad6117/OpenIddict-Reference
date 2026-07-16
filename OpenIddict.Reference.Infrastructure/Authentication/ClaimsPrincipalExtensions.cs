using System.Security.Claims;

namespace OpenIddict.Reference.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetClaim(
        this ClaimsPrincipal principal,
        string type)
    {
        return principal.FindFirst(type)?.Value;
    }
}
