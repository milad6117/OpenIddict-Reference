using Microsoft.EntityFrameworkCore;
using OpenIddict.Reference.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OpenIddict.Reference.Persistence.Context;

public sealed class ApplicationDbContext
    : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.UseOpenIddict();
    }
}