using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

namespace OpenIddict.Reference.Infrastructure.Seeders;

public sealed class ScopeSeeder
{
    #region Constructor
    private readonly IOpenIddictScopeManager _manager;

    private readonly IEnumerable<IScopeDescriptor> _descriptors;

    public ScopeSeeder(
        IOpenIddictScopeManager manager,
        IEnumerable<IScopeDescriptor> descriptors)
    {
        _manager = manager;
        _descriptors = descriptors;
    }
    #endregion

    public async Task SeedAsync()
    {
        foreach (var descriptor in _descriptors)
        {
            var scope = descriptor.Build();

            if (await _manager.FindByNameAsync(scope.Name!) is not null)
                continue;

            await _manager.CreateAsync(scope);
        }
    }
}
