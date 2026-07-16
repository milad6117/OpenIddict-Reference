using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Reference.Domain.Interfaces;
using OpenIddict.Reference.Infrastructure.Authentication;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace OpenIddict.Reference.API.Controllers;

public sealed class AuthorizationController : Controller
{
    #region Constructor
    private readonly IUserRepository _userRepository;
    private readonly ClaimsPrincipalFactory _claimsPrincipalFactory;

    public AuthorizationController(
        IUserRepository userRepository,
        ClaimsPrincipalFactory claimsPrincipalFactory)
    {
        _userRepository = userRepository;
        _claimsPrincipalFactory = claimsPrincipalFactory;
    }
    #endregion

    [HttpGet("~/connect/authorize")]
    [HttpPost("~/connect/authorize")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Authorize()
    {
        var request = HttpContext.GetOpenIddictServerRequest()
            ?? throw new InvalidOperationException();

        var result = await HttpContext.AuthenticateAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        if (result.Principal is null)
        {
            return Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = Request.Path + Request.QueryString
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        var subject = result.Principal.GetClaim(OpenIddictConstants.Claims.Subject);

        if (subject is null)
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = Request.Path + Request.QueryString
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        var user = await _userRepository.GetByIdAsync(Guid.Parse(subject));

        if (user is null)
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = Request.Path + Request.QueryString
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        var identity = _claimsPrincipalFactory.Create(user);

        var principal = new ClaimsPrincipal(identity);

        principal.SetScopes(request.GetScopes());

        principal.SetResources("resource_api");

        principal.SetDestinations(static claim => claim.Type switch
        {
            OpenIddictConstants.Claims.Name =>
            [
                OpenIddictConstants.Destinations.AccessToken,
                OpenIddictConstants.Destinations.IdentityToken
            ],

            OpenIddictConstants.Claims.Email =>
            [
                OpenIddictConstants.Destinations.AccessToken,
                OpenIddictConstants.Destinations.IdentityToken
            ],

            OpenIddictConstants.Claims.Role =>
            [
                OpenIddictConstants.Destinations.AccessToken,
                OpenIddictConstants.Destinations.IdentityToken
            ],

            _ =>
            [
                OpenIddictConstants.Destinations.AccessToken
            ]
        });

        return SignIn(
            principal,
            OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

 
}

