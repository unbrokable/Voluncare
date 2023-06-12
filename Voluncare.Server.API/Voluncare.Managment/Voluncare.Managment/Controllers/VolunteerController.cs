using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.HelpRequest;
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

        [HttpPost]
        [Route("showAcceptedHR")]
        public async Task<IActionResult> ShowAcceptedHR([FromBody] AcceptedHRViewModel viewModel)
        {
            IEnumerable<ListResponseViewModel> response;
            int? totalCount = 0;

            try
            {
                var result = await this.unitOfWork.HelpRequestRepository.GetListWithIncludeAsync(new Specification<HelpRequest>(hr => hr.TakenVolunteerId == viewModel.VolunteerId)
                    , viewModel.Page, viewModel.Count, default, include => include.User);
                totalCount = await this.unitOfWork.HelpRequestRepository.CountAsync(new Specification<HelpRequest>(hr => hr.TakenVolunteerId == viewModel.VolunteerId));

                response = this.mapper.Map<IEnumerable<ListResponseViewModel>>(result.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { list = response, count = totalCount });
        }
    }
}
