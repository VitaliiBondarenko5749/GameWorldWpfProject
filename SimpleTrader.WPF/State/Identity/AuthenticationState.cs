using GameWorldDomain.Models.Identity;
using GameWorldDomain.Services.Identity;
using GameWorldWpf.State.Identity.Interfaces;
using System;
using System.Threading.Tasks;

#pragma warning disable

namespace GameWorldWpf.State.Identity
{
    public class AuthenticationState : IAuthenticationState
    {
        private readonly IIdentityService identityService;
        private User? currentAccount;

        public AuthenticationState(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public User? CurrentUser
        {
            get { return currentAccount; }
            set
            {
                currentAccount = value;

                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

        public bool IsLoggedIn => CurrentUser != null;

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task LoginAsync(string email, string password)
        {
            CurrentUser = await identityService.LoginAsync(email, password);
        }

        public async Task<RegistrationResult> RegisterAsync(string name, string email, string password)
        {
            return await identityService.RegisterAsync(name, email, password);
        }
    }
}