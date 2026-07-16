using Microsoft.EntityFrameworkCore;
using OpenIddict.Reference.Domain.Entities;
using OpenIddict.Reference.Domain.Interfaces;
using OpenIddict.Reference.Persistence.Context;

namespace OpenIddict.Reference.Infrastructure.Seeders;

public sealed class UserSeeder
{
    #region Constructor
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public UserSeeder(
        ApplicationDbContext context,
        IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    #endregion

    public async Task SeedAsync()
    {
        if (await _context.Users.AnyAsync())
            return;

        var user = new User(
            "Milad",
            "admin@test.com",
            _passwordHasher.Hash("123456"),
            "Admin");

        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }
}
