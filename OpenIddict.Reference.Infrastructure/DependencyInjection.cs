using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Reference.Domain.Interfaces;
using OpenIddict.Reference.Infrastructure.Authentication;
using OpenIddict.Reference.Infrastructure.OpenIddict;
using OpenIddict.Reference.Infrastructure.OpenIddict.Abstractions;
using OpenIddict.Reference.Infrastructure.OpenIddict.Descriptors;
using OpenIddict.Reference.Infrastructure.Seeders;
using OpenIddict.Reference.Infrastructure.Services;

namespace OpenIddict.Reference.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ClaimsPrincipalFactory>();
        services.AddScoped<UserSeeder>();
        services.AddCookieAuthentication();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddOpenIddictServer(configuration);
        services.AddScoped<ClientSeeder>();
        services.AddScoped<ScopeSeeder>();
        services.AddScoped<OpenIddictSeeder>();
        services.AddScoped<IClientDescriptor, SwaggerClientDescriptor>();
        services.AddScoped<IClientDescriptor, IntrospectionClientDescriptor>();
        services.AddScoped<IScopeDescriptor, ResourceServerScopeDescriptor>();
        services.AddScoped<IClientDescriptor, ServiceClientDescriptor>();
        return services;
    }
}
