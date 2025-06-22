using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AuthApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly Repository _repository;
        private readonly IConfiguration _config;
        private readonly IPasswordHasherHelper _passwordHasherHelper;

        public AuthController(IConfiguration config, Repository repo, IPasswordHasherHelper passwordHasherHelper) {
            this._repository = repo;
            this._config = config;
            this._passwordHasherHelper = passwordHasherHelper;
        }

        [HttpGet("ping")]
        public IActionResult Ping() {
            return Ok("Pong");
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto user){
            Console.WriteLine($"New User:\n\tUsername: {user.Username}\n\tPassword: {user.Password}");
            User newUser = new User(user.Username?? "" , "");
            string hashedPassword = _passwordHasherHelper.HashPassword(newUser,user.Password ?? "");
            newUser.PasswordHash = hashedPassword;
            Console.WriteLine($"New user's hashed password is {hashedPassword}");
            await _repository.AddUser(newUser);
            string token = GenerateJwtToken(newUser.Username);
            return Ok(new {token});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user) {
            // Fine the user
            User? result = await _repository.FindUser(user.Username ?? "");

            // Validate Password
            if (result is not null) {
                if (_passwordHasherHelper.VerifyPassword(result, result.PasswordHash, user.Password ?? "")) {
                    // Login Success -> generate token
                    var token = GenerateJwtToken(result.Username);
                    return Ok (new {token});
                } else {
                    return Unauthorized("Invalid login credentials");
                }
            }
            // No user found
            return Unauthorized("Invalid login credentials");
        }

        [Authorize]
        [HttpGet("secret")]
        public async Task<IActionResult> Secret() {
            await Task.Delay(200);
            return Ok("Super secret thing");
        }

        // Hashes a new user's password
        private string HashPassword(User user, string password) {
            return _passwordHasherHelper.HashPassword(user, password);
        }

        private string GenerateJwtToken(string username) {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials 
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
