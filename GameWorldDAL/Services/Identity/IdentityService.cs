using GameWorldDomain.Models.Identity;
using GameWorldDomain.Services.Identity;
using Microsoft.AspNetCore.Identity;
using SimpleTrader.Domain.Exceptions;

namespace GameWorldDAL.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;

        public static string UserId { get; private set; } = null!;

        public IdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<RegistrationResult> RegisterAsync(string name, string email, string password)
        {
            User user = new() { UserName = name, Email = email };

            IdentityResult result = await userManager.CreateAsync(user, password);

            if (result.Errors.Any())
            {
                return RegistrationResult.Fail;
            }

            return RegistrationResult.Success;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            User? user = await userManager.FindByEmailAsync(email)
                ?? throw new UserNotFoundException($"User with email {email} was not found.");

            UserId = user.Id;

            bool isCorrectPassword = await userManager.CheckPasswordAsync(user, password);

            if (!isCorrectPassword)
            {
                throw new UserNotFoundException("Incorrect password.");
            }

            return user;
        }
    }
}