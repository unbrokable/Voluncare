using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class Staff : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid UserId { get; set; }

        public DateTime EmploymentDate { get; set; }

        public ApplicationUser User { get; set; }

        public VolunteerOrganization Organization { get; set; }
    }
}
