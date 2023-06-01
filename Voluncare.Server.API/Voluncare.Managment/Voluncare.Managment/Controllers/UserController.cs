using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Managment.Helpers;
using Voluncare.Managment.ViewModels;
using Voluncare.Managment.ViewModels.User;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IConfiguration configuration,
            IUnitOfWork unitOfWork
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel user)
        {
            var appUser = this.mapper.Map<ApplicationUser>(user);

            var result = await this.userManager.CreateAsync(appUser, user.Password);

            if (!result.Succeeded)
            {
                return BadRequest(user);
            }

            var token = JwtHelper.GetJwtToken(this.configuration);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel user)
        {
            var dbUser = await this.userManager.FindByNameAsync(user.UserName);

            var passwordVerification = this.userManager.PasswordHasher.VerifyHashedPassword(dbUser, dbUser.PasswordHash, user.Password);

            if (dbUser == null || passwordVerification != PasswordVerificationResult.Success)
            {
                return BadRequest(user);
            }

            var token = JwtHelper.GetJwtToken(this.configuration);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return Ok();
        }
    }
}
