namespace SurveyBasket.Api.Contracts.Authentication
{
    public record LoginRequest(
        string email,
        string password
        );

    
}
