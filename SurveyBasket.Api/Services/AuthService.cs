﻿using Mapster;
using SurveyBasket.Api.Authentication;

namespace SurveyBasket.Api.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager , IJwtProvider jwtProvider) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<AuthResponse?> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user is null)
                return null;

            var isValidPassword = await _userManager.CheckPasswordAsync(user , Password);

            if (!isValidPassword)
                return null;

            var (token , expiresIn) = _jwtProvider.GenerateToken(user);

            // Return New AuthResponse 
            return new AuthResponse (user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn);
        }
    }
}
