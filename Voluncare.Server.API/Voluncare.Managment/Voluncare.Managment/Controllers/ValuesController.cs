using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.Core.Specification;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("test")]
        public IActionResult TestGetAllAppUsers()
        {
            var result = this.unitOfWork.UserRepository.GetAsync(new Specification<ApplicationUser>(user => user == user));

            return Ok(new { users = result });
        }
    }
}
