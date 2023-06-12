using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class Comment : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid? OrganizationId { get; set; }

        public Guid UserId { get; set; }

        public Guid? ReceiverId { get; set; }

        public Guid? HelpRequestId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }

        public VolunteerOrganization Organization { get; set; }
    }
}
