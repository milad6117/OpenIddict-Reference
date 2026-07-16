using Microsoft.AspNetCore.Authentication;
using OpenIddict.Abstractions;
using OpenIddict.Reference.Domain.Entities;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace OpenIddict.Reference.Infrastructure.Authentication;

public sealed class ClaimsPrincipalFactory
{
    public ClaimsPrincipal Create(User user)
    {
        var identity = new ClaimsIdentity(
            OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        identity.AddClaim(OpenIddictConstants.Claims.Subject, user.Id.ToString());
        identity.AddClaim(OpenIddictConstants.Claims.Name, user.FullName);
        identity.AddClaim(OpenIddictConstants.Claims.Email, user.Email);
        identity.AddClaim(OpenIddictConstants.Claims.Role, user.Role.ToString());

        var principal = new ClaimsPrincipal(identity);

        principal.SetScopes(
            OpenIddictConstants.Scopes.OpenId,
            OpenIddictConstants.Scopes.Profile,
            OpenIddictConstants.Scopes.Email,
            OpenIddictConstants.Scopes.OfflineAccess,
            "resource_server");

        principal.SetResources("resource_server");

        foreach (var claim in principal.Claims)
        {
            switch (claim.Type)
            {
                case OpenIddictConstants.Claims.Name:
                case OpenIddictConstants.Claims.Email:
                    claim.SetDestinations(
                        OpenIddictConstants.Destinations.AccessToken,
                        OpenIddictConstants.Destinations.IdentityToken);
                    break;

                case OpenIddictConstants.Claims.Role:
                    claim.SetDestinations(
                        OpenIddictConstants.Destinations.AccessToken);
                    break;

                case OpenIddictConstants.Claims.Subject:
                    claim.SetDestinations(
                        OpenIddictConstants.Destinations.AccessToken,
                        OpenIddictConstants.Destinations.IdentityToken);
                    break;

                default:
                    claim.SetDestinations(
                        OpenIddictConstants.Destinations.AccessToken);
                    break;
            }
        }

        return principal;
    }
}

