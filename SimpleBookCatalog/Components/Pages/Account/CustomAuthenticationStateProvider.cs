namespace SimpleBookCatalog.Components.Pages.Account
{
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity()); // Default to an unauthenticated user.

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void NotifyUserAuthentication(ClaimsPrincipal user)
        {
            _currentUser = user;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity()); // Clear the user.
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }

}
