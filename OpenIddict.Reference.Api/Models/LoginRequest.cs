using System.ComponentModel.DataAnnotations;

namespace OpenIddict.Reference.API.Models;

public sealed class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;

    public string? ReturnUrl { get; set; }
}
