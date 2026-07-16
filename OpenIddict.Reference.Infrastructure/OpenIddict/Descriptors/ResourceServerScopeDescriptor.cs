using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

namespace OpenIddict.Reference.Infrastructure.OpenIddict.Descriptors;

public sealed class ResourceServerScopeDescriptor : IScopeDescriptor
{
    public OpenIddictScopeDescriptor Build()
    {
        return new OpenIddictScopeDescriptor
        {
            Name = "resource_server",

            DisplayName = "Resource Server",

            Resources =
            {
                "resource_server"
            }
        };
    }
}
