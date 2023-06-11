using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Services.Services
{
    public class VolunteerComputationService
    {
        private readonly IUnitOfWork unitOfWork;

        public VolunteerComputationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
