using Microsoft.AspNetCore.Authorization;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService): ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [Authorize]
        [HttpPost ("")]
        public async Task<IActionResult> LoginAsync (LoginRequest request , CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.email, request.password, cancellationToken);

            return authResult is null ? BadRequest("Invalid Email/Password") : Ok(authResult);
        }
    }
}
