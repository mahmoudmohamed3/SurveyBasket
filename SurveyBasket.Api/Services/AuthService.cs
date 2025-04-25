using Mapster;

namespace SurveyBasket.Api.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<AuthResponse?> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user is null)
                return null;

            var isValidPassword = await _userManager.CheckPasswordAsync(user , Password);

            if (!isValidPassword)
                return null;

            // Generate JWT Token

            // Return New AuthResponse 
            return new AuthResponse (user.Id, user.Email, user.FirstName, user.LastName, "hlhlhlhl", 1600 );
        }
    }
}
