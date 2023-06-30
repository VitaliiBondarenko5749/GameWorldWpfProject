using GameWorldDomain.Models.Identity;
using GameWorldDomain.Services.Identity;
using System;
using System.Threading.Tasks;

namespace GameWorldWpf.State.Identity.Interfaces
{
    public interface IAuthenticationState
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task<RegistrationResult> RegisterAsync(string name, string email, string password);
        Task LoginAsync(string email, string password);
        void Logout();
    }
}