using GameWorldDomain.Models.Identity;
using System.Threading.Tasks;

namespace GameWorldDomain.Services.Identity
{
    public enum RegistrationResult
    {
        Success,
        Fail
    }

    public interface IIdentityService
    {
        Task<RegistrationResult> RegisterAsync(string name, string email, string password);

        Task<User> LoginAsync(string email, string password);
    }
}