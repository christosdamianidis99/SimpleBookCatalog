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

builder.Services.AddDbContextFactory<SimpleBookCatalogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleBookCatalogConnection"), opts =>
    {
        opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });
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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

