using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Reference.Domain.Interfaces;
using OpenIddict.Reference.Infrastructure.Authentication;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace OpenIddict.Reference.API.Controllers;

public sealed class TokenController : Controller
{
    #region Constructor
    private readonly IUserRepository _userRepository;
    private readonly ClaimsPrincipalFactory _claimsPrincipalFactory;
    private readonly IOpenIddictApplicationManager _applicationManager;

    public TokenController(
        IUserRepository userRepository,
        ClaimsPrincipalFactory claimsPrincipalFactory,
        IOpenIddictApplicationManager applicationManager)
    {
        _userRepository = userRepository;
        _claimsPrincipalFactory = claimsPrincipalFactory;
        _applicationManager = applicationManager;
    }
    #endregion

 
    [HttpPost("~/connect/token")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest();

        if (request is null)
            throw new InvalidOperationException("OpenIddict request cannot be retrieved.");

        if (request.IsAuthorizationCodeGrantType() ||
            request.IsRefreshTokenGrantType())
        {
            var result = await HttpContext.AuthenticateAsync(
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            if (!result.Succeeded || result.Principal is null)
            {
                return Forbid(
                    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            return SignIn(
                result.Principal,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        if (request.IsClientCredentialsGrantType())
        {
            var application =
                await _applicationManager.FindByClientIdAsync(request.ClientId!)
                ?? throw new InvalidOperationException();

            var identity = new ClaimsIdentity(
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            identity.AddClaim(
                OpenIddictConstants.Claims.Subject,
                await _applicationManager.GetClientIdAsync(application));

            identity.AddClaim(
                OpenIddictConstants.Claims.Name,
                await _applicationManager.GetDisplayNameAsync(application)
                    ?? request.ClientId!);

            var principal = new ClaimsPrincipal(identity);

            principal.SetScopes(request.GetScopes());

            principal.SetResources( "resource_api");


            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(
                    OpenIddictConstants.Destinations.AccessToken);
            }

            Console.WriteLine(HttpContext.GetOpenIddictServerRequest()?.GrantType);

            return SignIn(
                principal,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        throw new NotSupportedException("The specified grant type is not supported.");
    }


}