using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voluncare.Core.Interfaces;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerOrganizationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VolunteerOrganizationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // public async Task<IActionResult> Index() { }
    }
}
