using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;
using Voluncare.Managment.ViewModels.Comments;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCommentViewModel viewModel)
        {
            try
            {
                var entity = this.mapper.Map<Comment>(viewModel);

                entity.Id = Guid.NewGuid();
                entity.Date = DateTime.UtcNow;

                await this.unitOfWork.CommentRepository.AddAsync(entity);

                await this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            return Ok();
        }

        [HttpPost]
        [Route("get")]
        public async Task<ActionResult<CommentResponseViewModel>> Get([FromBody] GetCommentViewModel viewModel)
        {
            IEnumerable<CommentResponseViewModel> commentResponse;

            try
            {
                var comments = await this.unitOfWork.CommentRepository.GetListWithIncludeAsync(new Specification<Comment>(cm => cm.ReceiverId == viewModel.ReceiverId),
                    1, 5, default, include => include.User);

                commentResponse = this.mapper.Map<IEnumerable<CommentResponseViewModel>>(comments.Items);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

            return Ok(commentResponse);
        }
    }
}
