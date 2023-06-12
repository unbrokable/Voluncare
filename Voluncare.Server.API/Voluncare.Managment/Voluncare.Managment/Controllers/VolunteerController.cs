using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.Comments;
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
            IEnumerable<CommentResponseViewModel> commentResponse;

            try
            {
                var result = await this.unitOfWork.UserRepository.GetWithIncludeAsync(new Specification<ApplicationUser>(user => user.Id == id));

                var comments = await this.unitOfWork.CommentRepository.GetListWithIncludeAsync(new Specification<Comment>(cm => cm.ReceiverId == id),
                    1, 5, default, include => include.User);

                if (result == null)
                {
                    return NotFound();
                }

                commentResponse = this.mapper.Map<IEnumerable<CommentResponseViewModel>>(comments.Items);
                volunteerBaseInfo = this.mapper.Map<VolunteerBaseInfoViewModel>(result);

                // business logic
                volunteerBaseInfo.TrustLevel = new Random().Next(0, 5);
                volunteerBaseInfo.AverageRating = new Random().Next(0, 5);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new { result = volunteerBaseInfo, comments = commentResponse });
        }

        [HttpPost]
        [Route("showAcceptedHR")]
        public async Task<ActionResult<ListResponseViewModel>> ShowAcceptedHR([FromBody] AcceptedHRViewModel viewModel)
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
