using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;

namespace OpenIddict.Reference.Infrastructure.Seeders;

public sealed class ClientSeeder
{
    #region Constructor
    private readonly IOpenIddictApplicationManager _manager;

    private readonly IEnumerable<IClientDescriptor> _descriptors;

    public ClientSeeder(
        IOpenIddictApplicationManager manager,
        IEnumerable<IClientDescriptor> descriptors)
    {
        _manager = manager;
        _descriptors = descriptors;
    }
    #endregion

    public async Task SeedAsync()
    {
        foreach (var descriptor in _descriptors)
        {
            var application = descriptor.Build();

            var existing = await _manager.FindByClientIdAsync(application.ClientId!);

            if (existing is null)
            {
                await _manager.CreateAsync(application);
                continue;
            }

            await _manager.UpdateAsync(existing, application);
        }
    }
}
