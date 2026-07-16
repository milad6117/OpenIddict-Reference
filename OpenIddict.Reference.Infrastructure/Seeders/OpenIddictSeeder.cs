namespace OpenIddict.Reference.Infrastructure.Seeders;

public sealed class OpenIddictSeeder
{
    #region Constructor
    private readonly ClientSeeder _clientSeeder;

    private readonly ScopeSeeder _scopeSeeder;

    public OpenIddictSeeder(
        ClientSeeder clientSeeder,
        ScopeSeeder scopeSeeder)
    {
        _clientSeeder = clientSeeder;
        _scopeSeeder = scopeSeeder;
    }
    #endregion

    public async Task SeedAsync()
    {
        await _scopeSeeder.SeedAsync();

        await _clientSeeder.SeedAsync();
    }
}