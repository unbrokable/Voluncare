using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.HelpRequest;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HelpRequestController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HelpRequestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateHelpRequest([FromBody] CreateHRViewModel viewModel)
        {
            var model = this.mapper.Map<HelpRequest>(viewModel);

            try
            {
                model.CreateDate = DateTime.UtcNow;
                model.Id = Guid.NewGuid();
                model.TakenVolunteerId = null;
                model.TakenOrganizationId = null;
                model.Status = Core.Enums.HelpRequestStatus.Draft;

                await this.unitOfWork.HelpRequestRepository.AddAsync(model);

                await this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        [Route("getList")]
        public async Task<ActionResult<ListResponseViewModel>> GetHelpRequestWithPagination([FromBody] GetWithPaginationViewModel viewModel)
        {
            IEnumerable<ListResponseViewModel> response;
            int? totalCount = 0;

            try
            {
                var result = await this.unitOfWork.HelpRequestRepository.GetListWithIncludeAsync(viewModel.Page, viewModel.Count, default, include => include.User);
                totalCount = await this.unitOfWork.HelpRequestRepository.CountAsync(new Specification<HelpRequest>(req => req == req));

                response = this.mapper.Map<IEnumerable<ListResponseViewModel>>(result.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { list = response, count = totalCount });
        }

        [HttpPost]
        [Route("getUnassignedList")]
        public async Task<ActionResult<ListResponseViewModel>> GetUnassignedHelpRequestsWithPagination([FromBody] GetWithPaginationViewModel viewModel)
        {
            IEnumerable<ListResponseViewModel> response;
            int? totalCount = 0;

            try
            {
                var result = await this.unitOfWork.HelpRequestRepository.GetListWithIncludeAsync(new Specification<HelpRequest>(hr => hr.TakenVolunteerId == null)
                    , viewModel.Page, viewModel.Count, default, include => include.User);
                totalCount = await this.unitOfWork.HelpRequestRepository.CountAsync(new Specification<HelpRequest>(hr => hr.TakenVolunteerId == null));

                response = this.mapper.Map<IEnumerable<ListResponseViewModel>>(result.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { list = response, count = totalCount });
        }

        [HttpPost]
        [Route("userRequests")]
        public async Task<ActionResult<ListResponseViewModel>> UserRequests([FromBody] UserRequestsViewModel viewModel)
        {
            IEnumerable<ListResponseViewModel> response;
            int? totalCount = 0;

            try
            {
                var result = await this.unitOfWork.HelpRequestRepository.GetListWithIncludeAsync(new Specification<HelpRequest>(hr => hr.UserId == viewModel.UserId)
                    , viewModel.Page, viewModel.Count, default, include => include.Volunteer);
                totalCount = await this.unitOfWork.HelpRequestRepository.CountAsync(new Specification<HelpRequest>(hr => hr.UserId == viewModel.UserId));

                response = this.mapper.Map<IEnumerable<ListResponseViewModel>>(result.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { list = response, count = totalCount });
        }


        [HttpPost]
        [Route("assingVolunteer")]
        public async Task<IActionResult> AssignVolunteer([FromBody] TakeRequestViewModel viewModel)
        {
            try
            {
                var hrModel = await this.unitOfWork.HelpRequestRepository.GetEntityAsync(new Specification<HelpRequest>(hr => hr.Id == viewModel.RequestId));

                hrModel.TakenVolunteerId = viewModel.TakenVolunteerId;
                hrModel.Status = Core.Enums.HelpRequestStatus.Accepted;
                hrModel.TakenDate = DateTime.UtcNow;

                await this.unitOfWork.HelpRequestRepository.UpdateAsync(hrModel);

                await this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok();
        }

        [HttpGet]
        [Route("totalCount")]
        public async Task<ActionResult<int>> GetTotalCount()
        {
            int result = 0;
            try
            {
                result = await this.unitOfWork.HelpRequestRepository.CountAsync(new Specification<HelpRequest>(req => req == req));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex });
            }

            return Ok(new { count = result });
        }
    }
}
