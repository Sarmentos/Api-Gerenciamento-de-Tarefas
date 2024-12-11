//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using SistemaDeTarefas.Models;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;

//namespace SistemaDeTarefas.Controllers
//{
//    [ApiController]
//    [Route("api/conta")]
//    public class RegiterController : ControllerBase
//    {
//        private readonly SignInManager<IdentityUser> _signInManager;
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly JwtSettings _jwtSettings;

//        public RegiterController(SignInManager<IdentityUser> signInManager,
//                       UserManager<IdentityUser> userManager,
//                       IOptions<JwtSettings> jwtSettings)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//            _jwtSettings = jwtSettings.Value;
//        }

//        [HttpPost("registrar")]
//        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
//        {
//            //if (!ModelState.IsValid) return ValidationProblem(ModelState);
//            if (!ModelState.IsValid) return Ok("ola");
//            var user = new IdentityUser
//            {
//                UserName = registerUser.Email,
//                Email = registerUser.Email,
//                EmailConfirmed = true
//            };

//            var result = await _userManager.CreateAsync(user, registerUser.Password);

//            if (result.Succeeded)
//            {
//                await _signInManager.SignInAsync(user, false);
//                return Ok();
//            }

//            return Problem("Falha ao registrar o usuario ");
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
//        {
//            if (!ModelState.IsValid) return ValidationProblem(ModelState);

//            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

//            if (result.Succeeded)
//            {
//                return Ok();
//            }

//            return Problem("Usuario ou senha incorretos");
//        }

//        //public string GerarJwt()
//        //{
//        //    var tokenHandler = new JwtSecurityTokenHandler();
//        //    var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);

//        //    var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
//        //    {
//        //        Issuer = _jwtSettings.Emissor,
//        //        Audience = _jwtSettings.Audiencia,
//        //        Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
//        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//        //    });

//        //    var encodedToken = tokenHandler.WriteToken(token);

//        //    return encodedToken;
//        //}
//    }
//}
