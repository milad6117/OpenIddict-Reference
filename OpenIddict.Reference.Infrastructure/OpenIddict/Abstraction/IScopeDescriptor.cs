using OpenIddict.Abstractions;

namespace OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

public interface IScopeDescriptor
{
    OpenIddictScopeDescriptor Build();
}
