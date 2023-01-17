using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService _AuthService { get; }
        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response  = await _AuthService.Register(new Shared.User() { Email = request.Email }
                                                        , request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _AuthService.Login(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(request);
            }
            return Ok(response);
        }
    }
}
