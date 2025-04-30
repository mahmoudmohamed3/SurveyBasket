using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using SurveyBasket.Api.Authentication;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService , IOptions<JwtOptions> jwtOptions): ControllerBase
    {
        private readonly IAuthService _authService = authService;


        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.email, request.password, cancellationToken);

            return authResult is null ? BadRequest("Invalid Email/Password") : Ok(authResult);
        }

    }
}
