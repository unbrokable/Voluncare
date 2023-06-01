using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class VolunteerOrganization : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid FounderId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BackgroundImage { get; set; }

        public ApplicationUser Founder { get; set; }

        public List<Chat> Chats { get; set; }

        public List<HelpRequest> HelpRequests { get; set; }

        public List<Staff> Staffs { get; set; }

        public List<Estimate> Estimates { get; set; }

        public List<OrganizationContact> OrganizationContacts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
