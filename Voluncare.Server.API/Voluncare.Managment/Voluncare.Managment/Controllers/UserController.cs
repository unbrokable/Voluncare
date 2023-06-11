using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Mail;
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
            ApplicationUser dbUser = null;
            JwtSecurityToken token = null;

            try
            {
                var appUser = this.mapper.Map<ApplicationUser>(user);

                var result = await this.userManager.CreateAsync(appUser, user.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(user);
                }

                dbUser = await this.userManager.FindByNameAsync(user.UserName);

                token = JwtHelper.GetJwtToken(this.configuration);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                user = dbUser
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel user)
        {
            ApplicationUser dbUser = null;
            JwtSecurityToken token = null;

            try
            {
                dbUser = await this.userManager.FindByNameAsync(user.UserName);

                var passwordVerification = this.userManager.PasswordHasher.VerifyHashedPassword(dbUser, dbUser.PasswordHash, user.Password);

                if (dbUser == null || passwordVerification != PasswordVerificationResult.Success)
                {
                    return BadRequest(user);
                }

                token = JwtHelper.GetJwtToken(this.configuration);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                user = dbUser
            });
        }

        [HttpPost]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel user)
        {
            ApplicationUser dbUser = null;

            try
            {
                dbUser = await this.userManager.FindByIdAsync(user.Id.ToString());

                dbUser = this.mapper.Map(user, dbUser);

                var result = await this.userManager.UpdateAsync(dbUser);

                if (!result.Succeeded)
                {
                    return BadRequest(user);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            return Ok(new
            {
                user = dbUser
            });
        }

        [HttpPost]
        [Authorize]
        [Route("uploadImage")]
        public async Task<IActionResult> UploadImage (IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not selected");
            }

            string connectionString = this.configuration["BlobConnectionString"];

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            string containerName = this.configuration["BlobContainerName"];

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var fileName = String.Concat(Guid.NewGuid().ToString(), file.FileName);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            BlobContentInfo result;

            using (var stream = file.OpenReadStream())
            {
                result = await blobClient.UploadAsync(stream, true);
            }

            return Ok(new
            {
                imageUrl = String.Concat("https://voluncarestorage.blob.core.windows.net/userimages/", fileName)
            });
        }

        //private static void SendEmail(string toEmail, FunctionContext context)
        //{
        //    var config = context.GetConfig();

        //    string fromEmail = config["FromEmail"];
        //    string fromPassword = config["FromPassword"];
        //    string smtpHost = config["SmtpHost"];
        //    int smtpPort = int.Parse(config["SmtpPort"]);

        //    using MailMessage mail = new MailMessage
        //    {
        //        From = new MailAddress(fromEmail),
        //        Subject = "Custom time email notification",
        //        Body = $"This is your custom time email notification, {toEmail}.",
        //        IsBodyHtml = false
        //    };

        //    mail.To.Add(toEmail);

        //    using SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
        //    {
        //        Credentials = new NetworkCredential(fromEmail, fromPassword),
        //        EnableSsl = true
        //    };

        //    try
        //    {
        //        smtpClient.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        context.GetLogger("SendEmail").LogError($"Error sending email to {toEmail}: {ex.Message}");
        //    }
        //}
    }
}
