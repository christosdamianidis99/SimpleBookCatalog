using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Components;
using SimpleBookCatalog.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "auth_token";
    options.LoginPath = "/login";
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    options.AccessDeniedPath = "/access-denied";
}

);

builder.Services.AddDbContextFactory<SimpleBookCatalogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookCatalogConnection"), opts =>
    {
        opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });
});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddServerSideBlazor();


builder.Services.AddAntiforgery(options =>
{     // Set Cookie properties using CookieBuilder properties†.

    options.Cookie.Expiration = TimeSpan.Zero;

});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.UseStaticFiles();

app.MapRazorComponents<App>().DisableAntiforgery().AddInteractiveServerRenderMode();


app.Run();

