using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenIddict.Reference.Infrastructure.OpenIddict.Descriptors
{
    public sealed class SwaggerClientDescriptor : IClientDescriptor
    {
        public OpenIddictApplicationDescriptor Build()
        {
            return new ()
            {
                ClientId = "swagger",

                ConsentType = OpenIddictConstants.ConsentTypes.Explicit,

                DisplayName = "Swagger",

                ClientType = OpenIddictConstants.ClientTypes.Public,

                RedirectUris =
    {
        new Uri("https://localhost:5005/swagger/oauth2-redirect.html"),
        new Uri("https://oauth.pstmn.io/v1/callback")
    },

                Permissions =
    {
        OpenIddictConstants.Permissions.Endpoints.Authorization,
        OpenIddictConstants.Permissions.Endpoints.Token,
        OpenIddictConstants.Permissions.Endpoints.Revocation,
        OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
        OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
        OpenIddictConstants.Permissions.ResponseTypes.Code,

     OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.OpenId,
OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.Profile,
OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.Email,
OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.OfflineAccess,
OpenIddictConstants.Permissions.Prefixes.Scope + "resource_server",
    },

                Requirements =
    {
        OpenIddictConstants.Requirements.Features.ProofKeyForCodeExchange
    }
            };
        }
    }
}

