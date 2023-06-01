using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Enums;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class HelpRequest : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid TakenOrganizationId { get; set; }

        public Guid TakenVolunteerId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public HelpRequestStatus Status { get; set; }

        public DateTime TakenDate { get; set; }

        public ApplicationUser User { get; set; }

        public VolunteerOrganization? Organization { get; set; }
    }
}
