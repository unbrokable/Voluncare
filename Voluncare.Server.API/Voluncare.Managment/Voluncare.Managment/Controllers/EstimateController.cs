using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.Estimate;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EstimateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("estimateVolunteer")]
        public async Task<IActionResult> EstimateVolunteer([FromBody] EstimateVolunteerViewModel viewModel)
        {
            try
            {
                var entity = this.mapper.Map<Estimate>(viewModel);

                entity.Created = DateTime.UtcNow;
                entity.Id = Guid.NewGuid();

                await this.unitOfWork.EstimateRepository.AddAsync(entity);

                await this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        [Route("getAvgEstimate")]
        public async Task<ActionResult<ResponseAvgEstimateViewModel>> GetAvgEstimate([FromBody] GetAvgEstimateViewModel viewModel)
        {
            ResponseAvgEstimateViewModel response = new ResponseAvgEstimateViewModel();

            try
            {
                response.AverageEstimate = await this.unitOfWork.EstimateRepository.AverageAsync(
                    new Specification<Estimate>(es => es.Created > viewModel.Start && es.Created < viewModel.End),
                    prop => prop.Rating);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(response);
        }
    }
}
