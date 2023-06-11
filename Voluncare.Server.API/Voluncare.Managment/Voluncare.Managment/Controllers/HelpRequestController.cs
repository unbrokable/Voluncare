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

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateHelpRequest([FromBody] CreateHRViewModel viewModel)
        {
            var model = this.mapper.Map<HelpRequest>(viewModel);

            try
            {
                model.CreateDate = DateTime.Now;
                model.Id = Guid.NewGuid();
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

        [Route("getList")]
        [HttpPost]
        public async Task<ActionResult<ListResponseViewModel>> GetHelpRequestWithPagination([FromBody] GetWithPaginationViewModel viewModel)
        {
            List<ListResponseViewModel> response;

            try
            {
                var result = await this.unitOfWork.HelpRequestRepository.GetAsync(viewModel.Page, viewModel.Count);

                response = this.mapper.Map<List<ListResponseViewModel>>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { list = response });
        }

        [Route("assingVolunteer")]
        [HttpPost]
        public async Task<IActionResult> AssignVolunteer([FromBody] TakeRequestViewModel viewModel)
        {
            try
            {
                var hrModel = await this.unitOfWork.HelpRequestRepository.GetEntityAsync(new Specification<HelpRequest>(hr => hr.Id == viewModel.RequestId));

                hrModel.TakenVolunteerId = viewModel.TakenVolunteerId;
                hrModel.Status = Core.Enums.HelpRequestStatus.InProgress;
                hrModel.TakenDate = DateTime.Now;

                await this.unitOfWork.HelpRequestRepository.UpdateAsync(hrModel);

                await this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok();
        }
    }
}
