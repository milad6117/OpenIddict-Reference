using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.Options;
using OpenIddict.Reference.Persistence.Context;



namespace OpenIddict.Reference.Infrastructure.OpenIddict;

public static class OpenIddictExtensions
{
    public static IServiceCollection AddOpenIddictServer(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var settings = configuration
            .GetSection(OpenIddictOptions.SectionName)

            .Get<OpenIddictOptions>()!;

        services.AddOpenIddict()

            .AddCore(options =>
            {
                options.UseEntityFrameworkCore()
                       .UseDbContext<ApplicationDbContext>();
            })

            .AddServer(options =>
            {
                options.SetIssuer(new Uri(settings.Issuer));

                options.SetAuthorizationEndpointUris("/connect/authorize");

                options.SetTokenEndpointUris("/connect/token");

                options.SetUserInfoEndpointUris("/connect/userinfo");

                options.SetRevocationEndpointUris("/connect/revoke");

                options.SetIntrospectionEndpointUris("/connect/introspect");

                options.AllowAuthorizationCodeFlow();

                options.AllowRefreshTokenFlow();

                options.AllowClientCredentialsFlow();

                options.RequireProofKeyForCodeExchange();

                options.UseReferenceAccessTokens();
                options.UseReferenceRefreshTokens();
                options.RegisterScopes(
                    OpenIddictConstants.Scopes.OpenId,
                    OpenIddictConstants.Scopes.Profile,
                    OpenIddictConstants.Scopes.Email,
                    OpenIddictConstants.Scopes.OfflineAccess);

          
                options.AddDevelopmentEncryptionCertificate();

                options.AddDevelopmentSigningCertificate();

                options.UseAspNetCore()
                    .EnableAuthorizationEndpointPassthrough()
                    .EnableTokenEndpointPassthrough()
                    .EnableUserInfoEndpointPassthrough()
                    .EnableStatusCodePagesIntegration();

            })

            .AddValidation(options =>
            {
                options.UseLocalServer();

                options.UseAspNetCore();
            
            });

        return services;
    }
}
