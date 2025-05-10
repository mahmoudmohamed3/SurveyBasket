using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using SurveyBasket.Api.Authentication;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService , IOptions<JwtOptions> jwtOptions , UserManager<ApplicationUser> userManager): ControllerBase
    {
        private readonly IAuthService _authService = authService;

        private readonly UserManager<ApplicationUser> _userManager = userManager;


        [HttpPost("")]
        public async Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.email, request.password, cancellationToken);

            return authResult is null ? BadRequest("Invalid Email/Password") : Ok(authResult);
        }

        [HttpPost("Reg")]
        public async Task<IActionResult> CreateUserAsync(string email, string firstName, string lastName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await _userManager.CreateAsync(user, password);

            return Ok();
        }






    }
}
