using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace OpenIddict.Reference.API.Controllers;

[ApiController]
public sealed class UserInfoController : Controller
{
    [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
    [HttpGet("~/connect/userinfo")]
    [HttpPost("~/connect/userinfo")]
    public async Task<IActionResult> UserInfo()
    {
        var result = await HttpContext.AuthenticateAsync(
            OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        if (!result.Succeeded || result.Principal is null)
        {
            return Challenge(
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        var principal = result.Principal;

        return Ok(new
        {
            sub = principal.GetClaim(OpenIddictConstants.Claims.Subject),
            name = principal.GetClaim(OpenIddictConstants.Claims.Name),
            email = principal.GetClaim(OpenIddictConstants.Claims.Email),
            role = principal.GetClaim(OpenIddictConstants.Claims.Role)
        });
    }
}
