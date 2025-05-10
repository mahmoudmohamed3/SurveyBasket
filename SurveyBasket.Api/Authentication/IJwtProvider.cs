namespace SurveyBasket.Api.Authentication
{
    public interface IJwtProvider
    {
        (string token , int expiresIn) GenerateToken (ApplicationUser user);
        public string? ValidateToken(string token);
    }
}
