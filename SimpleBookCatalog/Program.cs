using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorClassLibraryMain.Account;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Components;
using SimpleBookCatalog.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();


// Configure EF Core and repositories
builder.Services.AddDbContextFactory<SimpleBookCatalogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookCatalogConnection"), opts =>
    {
        opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });
});

// Configure authentication and Google login
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.Cookie.Name = "auth_token";
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/access-denied";
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
})
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "google-id";
    googleOptions.ClientSecret = "google-secret";
});

// Configure authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});


// Configure antiforgery settings
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Expiration = TimeSpan.Zero;
});

// Register application services and repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication(); // Must come before UseAuthorization
app.UseAuthorization();

app.MapControllers();

//This is one for some reason deactivate the rendermode
//app.MapBlazorHub();

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(new[] { typeof(RazorClassLibraryMain.Account.Login).Assembly })
    .DisableAntiforgery() // Use cautiously; consider enabling antiforgery if needed
    .AddInteractiveServerRenderMode();

app.Run();
