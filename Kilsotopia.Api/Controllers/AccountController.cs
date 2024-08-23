using Kilsotopia.Application.Common.DTOs;
using Kilsotopia.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Kilsotopia.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly JWTService _jWTService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(JWTService jWTService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _jWTService = jWTService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("refresh-user-token")]
        public async Task<ActionResult<ApplicationUserDto>> RefreshUserToken()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Email)?.Value);
            return CreateApplicationUserDto(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            if (user.EmailConfirmed == false)
            {
                return Unauthorized("Please confirm your email.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password");
            }

            return CreateApplicationUserDto(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
             if (await CheckEmailExistsAsync(model.Email))
            {
                return BadRequest($"An existing acount is using {model.Email}, email address. Please try with another email address.");
            }

            var userToAdd = new ApplicationUser
            {
                FirstName = model.FirstName.ToLower(),
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userToAdd, model.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Your account has been created, you can login");
        } 

        #region Private Helper Methods
        private ApplicationUserDto CreateApplicationUserDto(ApplicationUser user)
        {
            return new ApplicationUserDto
            {
                FirstName = user.FirstName,
                JWT = _jWTService.CreateJWT(user),
            };
        }

        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }
        #endregion
    }
}
