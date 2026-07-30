using FlightPal.Models.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace FlightPal.Services
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IHttpContextAccessor _httpContextAccesor;

        private readonly ClaimsPrincipal _anonymous =
            new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage, IHttpContextAccessor httpContextAccesor)
        {
            _sessionStorage = sessionStorage;
            _httpContextAccesor = httpContextAccesor;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var httpContext = _httpContextAccesor.HttpContext;

                if(httpContext.User?.Identity?.IsAuthenticated == true)
                {
                    return new AuthenticationState(httpContext.User);
                }



                // Leer sesión del storage
                var userSessionStorageResult = await _sessionStorage.GetAsync<Users>("UserSession");

                var userSession = userSessionStorageResult.Success ?
                    userSessionStorageResult.Value : null;

                if (userSession == null)
                    return new AuthenticationState(_anonymous);

                // Crear claims principal
                var claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, userSession.Id_user.ToString()),
                        new Claim(ClaimTypes.Email, userSession.Email),
                        new Claim(ClaimTypes.Name, $"{userSession.Nombre} {userSession.Apellido}"),
                        new Claim(ClaimTypes.Role, userSession.Role)
                    }, "CookieAuth"));

                return new AuthenticationState(claimsPrincipal);
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public async Task UpdateAuthenticationState(Users? userSession, HttpContext? httpContext = null)
        {
            ClaimsPrincipal claimsPrincipal;


            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, userSession.Id_user.ToString()),
                        new Claim(ClaimTypes.Email, userSession.Email),
                        new Claim(ClaimTypes.Name, $"{userSession.Nombre} {userSession.Apellido}"),
                        new Claim(ClaimTypes.Role, userSession.Role)
                    }, "CookieAuth"));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
