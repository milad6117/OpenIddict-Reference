namespace OpenIddict.Reference.Infrastructure.Options;

public sealed class OpenIddictOptions
{
    public const string SectionName = "OpenIddict";

    public string Issuer { get; set; } = string.Empty;
}
