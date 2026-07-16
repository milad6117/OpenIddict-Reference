using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;

namespace OpenIddict.Reference.API.Controllers;

[ApiController]
[Route("api/protected")]
public sealed class ProtectedController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Subject = User.GetClaim(OpenIddictConstants.Claims.Subject),

            Name = User.GetClaim(OpenIddictConstants.Claims.Name),

            Claims = User.Claims.Select(x => new
            {
                x.Type,
                x.Value
            })
        });
    }
}
