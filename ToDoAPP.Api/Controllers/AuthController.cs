using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ToDoAPP.Api.Auth;
using ToDoAPP.Api.Db;
using ToDoAPP.Api.Db.Entities;
using ToDoAPP.Api.Repositories;
using ToDoAPP.Api.Models.Requests;

namespace ToDoAPP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private TokenGenerator _tokenGenerator;
        private UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ISendEmailRequestRepository _sendEmailRequestRepository;
        public AuthController(IConfiguration configuration, TokenGenerator tokenGenerator, UserManager<UserEntity> userManager, ISendEmailRequestRepository sendEmailRequestRepository)
        {
            _configuration = configuration;
            _sendEmailRequestRepository = sendEmailRequestRepository;
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
        }

        [HttpPost("ping")]
        [HttpGet("ping")]
        public string Ping()
        {
            return "Pong";
        }



        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var entity = new UserEntity();
            entity.UserName = request.Email;
            entity.Email = request.Email;
            var result = await _userManager.CreateAsync(entity, request.Password);

            if (!result.Succeeded)
            {
                var firstError = result.Errors.First();
                return BadRequest(firstError.Description);
            }

            return Ok();

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("User Not Found!");

            }

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isCorrectPassword)
            {
                return BadRequest("Invalid Email or Password");
            }

            return Ok(_tokenGenerator.Generate(request.Email));
        }







        //RequestPasswordReset
        // 1 - validate token
        // 2 - validate new password
        // 3 re



        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetRequest request)
        {
            // 0 -  find user
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("User Not Found");

            }

            // 1 -  generate password reset token

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            // 2 -  insert email into sendEmailRequest table

            var sendEmailRequestEntity = new SendEmailRequestEntity();
            sendEmailRequestEntity.ToAdress = request.Email;
            sendEmailRequestEntity.Status = SendEmailRequestStatus.New;
            sendEmailRequestEntity.CreatedAt = DateTime.Now;



            //  $" <a href=\"https://localhost:7261/api/Auth/reset-password/{token}\"> Reset Password</a>";
            var url = _configuration["PasswordResetUrl"]!
                .Replace("{userId}", user.Id.ToString())
                .Replace("{token}", token);
            var resetUrl = $"<a href=\"{url}\" > Reset password </a>";
            sendEmailRequestEntity.Body = $"Hello, your password reset link is :{resetUrl} ";

            _sendEmailRequestRepository.Insert(sendEmailRequestEntity);
            await _sendEmailRequestRepository.SaveChangesAsync();

            // 3 -  return result
            return Ok();


        }

        [HttpPost("reset-password/{token}")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserID.ToString());

            if (user == null)
            {
                return NotFound("user not found");
            }

            var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);



            if (!resetResult.Succeeded)
            {
                var firstError = resetResult.Errors.First();
                return StatusCode(500, firstError.Description);
            }


            return Ok();
        }


    }
}
