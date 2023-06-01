using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Interfaces;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
