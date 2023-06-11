using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.Volunteer;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;

        public VolunteerController(
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
        [Route("getInfo")]
        public async Task<IActionResult> GetInfo([FromBody] Guid id)
        {
            VolunteerBaseInfoViewModel volunteerBaseInfo;

            try
            {
                var result = await this.unitOfWork.UserRepository.GetEntityAsync(new Specification<ApplicationUser>(user => user.Id == id));

                if (result == null)
                {
                    return NotFound();
                }

                volunteerBaseInfo = this.mapper.Map<VolunteerBaseInfoViewModel>(result);

                // business logic
                volunteerBaseInfo.TrustLevel = new Random().Next(0, 5);
                volunteerBaseInfo.AverageRating = new Random().Next(0, 5);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { result = volunteerBaseInfo });
        }
    }
}
