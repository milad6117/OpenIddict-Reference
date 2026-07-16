using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

public sealed class ServiceClientDescriptor : IClientDescriptor
{
    public OpenIddictApplicationDescriptor Build()
    {
        return new()
        {
            ClientId = "service-worker",

            ClientSecret = "service-worker-secret",

            ClientType = OpenIddictConstants.ClientTypes.Confidential,

            Permissions =
            {
                OpenIddictConstants.Permissions.Endpoints.Token,

                OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,

                OpenIddictConstants.Permissions.Prefixes.Scope + "resource_server"
            }
        };
    }
}
