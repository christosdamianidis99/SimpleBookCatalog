using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBookCatalog.Domain.Entities;
using System.Security.Claims;


namespace SimpleBookCatalog.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GoogleResponseAsync()
        {
            // Authenticate the user
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded || authenticateResult.Principal == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Extract email from Google claims
            var email = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
            var name = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrEmpty(email))
            {
                // Handle cases where email is not available
                return RedirectToAction("Error", "Home");
            }

            // Check if the user exists in your UserAccounts table
            using (var scope = HttpContext.RequestServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SimpleBookCatalogDbContext>();

                var userAccount = dbContext.UserAccounts.FirstOrDefault(u => u.Email == email);
                if (userAccount == null)
                {
                    // If user doesn't exist, create a new entry with a default role
                    userAccount = new UserAccount
                    {
                        UserName = name ?? email, // Use Google name or email as the username
                        Email = email,
                        Role = "User", // Default role
                        Password = ""  // No password for Google users
                    };
                    dbContext.UserAccounts.Add(userAccount);
                    await dbContext.SaveChangesAsync();
                }

                // Create claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userAccount.UserName),
            new Claim(ClaimTypes.Email, userAccount.Email),
            new Claim(ClaimTypes.Role, userAccount.Role)
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }

            return Redirect("/"); // Redirect to the main page or a specific route
        }

    }
}
