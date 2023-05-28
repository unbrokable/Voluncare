using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel user)
        {
            var appUser = this.mapper.Map<ApplicationUser>(user);

            var result = await this.userManager.CreateAsync(appUser, user.Password);

            if (!result.Succeeded)
            {
                return new JsonResult(user) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
            else
            {
                await this.signInManager.SignInAsync(appUser, false);

                return new JsonResult(user) { StatusCode = (int)HttpStatusCode.OK };
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel user)
        {
            var dbUser = await this.userManager.FindByNameAsync(user.UserName);

            var passwordVerification = this.userManager.PasswordHasher.VerifyHashedPassword(dbUser, dbUser.PasswordHash, user.Password);

            if (dbUser == null || passwordVerification != PasswordVerificationResult.Success)
            {
                return new JsonResult(user) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            await this.signInManager.SignInAsync(dbUser, false);

            // HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "set-cookie");

            return new JsonResult(dbUser) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}
