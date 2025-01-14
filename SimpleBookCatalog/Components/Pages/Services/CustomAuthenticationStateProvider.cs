namespace SimpleBookCatalog.Services
{
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private Task<AuthenticationState> _authenticationState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return _authenticationState;
        }

        public void SetAuthenticationState(Task<AuthenticationState> authenticationStateTask)
        {
            Console.WriteLine("Updating authentication state...");
            _authenticationState = authenticationStateTask;
            NotifyAuthenticationStateChanged(authenticationStateTask);
        }


        public void Logout()
        {
            var anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            SetAuthenticationState(Task.FromResult(anonymous));
        }
    }

}
