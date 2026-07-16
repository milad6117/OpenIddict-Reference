
using Microsoft.OpenApi;
using OpenIddict.Reference.Infrastructure;
using OpenIddict.Reference.Infrastructure.Seeders;
using OpenIddict.Reference.Persistence;
using OpenIddict.Validation.AspNetCore;



;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

#region Swagger Config
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OpenIddict Reference",
        Version = "v1"
    });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,

        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5005/connect/authorize"),

                TokenUrl = new Uri("https://localhost:5005/connect/token"),

                Scopes = new Dictionary<string, string>
                {
                    ["openid"] = "OpenId",
                    ["profile"] = "Profile",
                    ["email"] = "Email",
                    ["offline_access"] = "Offline Access",
                    ["resource_server"] = "Resource Server"
                    
                }
            }
        }
    });

    options.AddSecurityRequirement(document =>
    {
        return new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference("oauth2", document)
            ] = []
        };
    });
});
#endregion

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
//builder.Services.AddAuthorization();
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddDataProtection();




var app = builder.Build();

#region Seed Data
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<UserSeeder>();

    await seeder.SeedAsync();
}

using (var scope = app.Services.CreateScope())
{
    var users = scope.ServiceProvider.GetRequiredService<UserSeeder>();

    await users.SeedAsync();

    var openiddict = scope.ServiceProvider.GetRequiredService<OpenIddictSeeder>();

    await openiddict.SeedAsync();
}
#endregion


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    //app.MapOpenApi();

    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenIddict");

        options.OAuthClientId("swagger");

        options.OAuthAppName("Swagger");

        options.OAuthUsePkce();
      
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();
app.Run();


