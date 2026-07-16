using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace OpenIddict.Reference.Infrastructure.Authentication;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddCookieAuthentication(
        this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        })
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";

            options.Cookie.Name = "OpenIddict.Reference";

            options.Cookie.HttpOnly = true;

            options.Cookie.SameSite = SameSiteMode.Lax;

            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            options.SlidingExpiration = true;

            options.ExpireTimeSpan = TimeSpan.FromHours(8);
        });

        services.AddAuthorization();

        return services;
    }
}
