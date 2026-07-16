using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace OpenIddict.Reference.API.Controllers;

[ApiController]
public sealed class RevocationController : Controller
{
    [HttpPost("~/connect/revoke")]
    public IActionResult Revoke()
    {
        var request = HttpContext.GetOpenIddictServerRequest()
            ?? throw new InvalidOperationException("OpenIddict request cannot be retrieved.");

        return SignOut(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}
