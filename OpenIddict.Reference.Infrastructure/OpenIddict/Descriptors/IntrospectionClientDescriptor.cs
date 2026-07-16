using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

public sealed class IntrospectionClientDescriptor : IClientDescriptor
{
    public OpenIddictApplicationDescriptor Build()
    {
        return new()
        {
            ClientId = "resource_api",

            ClientSecret = "resource_api_secret",

            ClientType = OpenIddictConstants.ClientTypes.Confidential,

            Permissions =
            {
                OpenIddictConstants.Permissions.Endpoints.Introspection,
                OpenIddictConstants.Permissions.Prefixes.Scope + "resource_server",
                 OpenIddictConstants.Permissions.Prefixes.Resource + "resource_server"
            }
        };
    }
}
