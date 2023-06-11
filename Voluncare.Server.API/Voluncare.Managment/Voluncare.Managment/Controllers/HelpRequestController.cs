using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
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
                await this.unitOfWork.HelpRequestRepository.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok();
        }

        [Route("getList")]
        [HttpPost]
        public async Task<IActionResult> GetHelpRequestWithPagination([FromBody] GetWithPaginationViewModel viewModel)
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
    }
}
