using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenIddict.Reference.API.Models;
using OpenIddict.Reference.Domain.Interfaces;
using OpenIddict.Reference.Infrastructure.Authentication;
using System.Security.Claims;

namespace OpenIddict.Reference.API.Pages.Account;


public sealed class LoginModel : PageModel
{
    #region Constructor
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ClaimsPrincipalFactory _claimsPrincipalFactory;

    public LoginModel(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ClaimsPrincipalFactory claimsPrincipalFactory)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _claimsPrincipalFactory = claimsPrincipalFactory;
    }
    #endregion

    [BindProperty]
    public LoginRequest Input { get; set; } = new();

    public void OnGet(string? returnUrl)
    {
        Input.ReturnUrl = returnUrl;
    }


    public async Task<IActionResult> OnPostAsync()
    {



        if (!ModelState.IsValid)
            return Page();

        var user = await _userRepository.GetByEmailAsync(Input.Email);

        if (user is null)
        {
            throw new Exception("user not found");
            ModelState.AddModelError("", "Invalid email or password");
            return Page();
        }

        if (!_passwordHasher.Verify(Input.Password, user.PasswordHash))
        {
            ModelState.AddModelError("", "Invalid email or password");
            return Page();
        }

        var identity = _claimsPrincipalFactory.Create(user);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        if (!string.IsNullOrWhiteSpace(Input.ReturnUrl))
            return LocalRedirect(Input.ReturnUrl);

        return Redirect("/");
    }



}
