using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.DTO;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Response<int>>> Register(UserRegisterDTO request)
        {
            var response = await _authRepo.Register(
                new User (){ UserName = request.Username }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<int>>> Login(UserLoginDTO request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
